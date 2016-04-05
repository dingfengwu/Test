/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：SecurityMiddleware.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-26 11:32:45
//----------------------------------------------------------------*/



using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Internal;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using Kehu1688.Framework.Base;

namespace Kehu1688.Framework.Middleware
{
    public class SecurityMiddleware
    {
        const string SIGN_KEY = "sign";//签名key
        const string TIME_STAMP = "timestamp";//时间戳key
        const int TIME_STAMP_DIFF = 5 * 60;//与客户端时间相差不能超过5分钟
        RequestDelegate _next;
        SecurityMiddlewareOption _options;
        HttpContext _context;
        ILogger _logger;

        public SecurityMiddleware(RequestDelegate next, SecurityMiddlewareOption options,ILoggerFactory logger)
        {
            if (next == null)
                throw new ArgumentNullException(nameof(next));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _next = next;
            _options = options;
            _logger = logger.CreateLogger(nameof(SecurityMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            _context = context;

            try
            {
                if (_options.AllowArgumentEncrypt) await Decode();
                if (_options.ValidateData) await Verify();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _context.Response.StatusCode = 400;
                throw ex;
            }
            finally
            {
                await _next(context);
            }
        }

        /// <summary>
        /// 解码字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        #pragma warning disable 1998
        private async Task Decode()
        {
            if(_options.AllowArgumentEncrypt)
            {
                string[] values = null;
                var queryString = _context.Request.QueryString.Value;
                var queryCollection = _context.Request.Query;
                var formCollection = _context.Request.HasFormContentType ? _context.Request.Form : null;
                
                //解析查询字符串
                if(queryString.Length>0)
                {
                    StringBuilder arguments = new StringBuilder();
                    queryString = queryString.Substring(1);
                    foreach(var item in queryString.Split('&'))
                    {
                        var key = item.Split('=')[0];
                        var value = item.Split('=')[1];
                        value = Decrypt(value);

                        arguments.Append($"{key}={value}");
                        arguments.Append("&");
                    }
                    if(arguments.ToString().EndsWith("&"))
                    {
                        arguments.Remove(arguments.Length - 1, 1);
                    }
                    _context.Request.QueryString = new QueryString(queryString);
                }

                //解析查询字符串集合
                if (queryCollection != null && queryCollection.Count > 0)
                {
                    var queryDict = new Dictionary<string, StringValues>();
                    ReadableStringCollection query = new ReadableStringCollection(queryDict);
                    foreach (var item in queryCollection)
                    {
                        var key = item.Key;
                        values = new string[item.Value.Count];
                        for (var i = 0; i < values.Length; i++)
                        {
                            values[i] = Decrypt(item.Value[i]);
                        }

                        queryDict.Add(key, new StringValues(values));
                    }
                    _context.Request.Query = query;
                }

                //解析Form集合
                if (formCollection != null && formCollection.Count > 0)
                {
                    var formDict = new Dictionary<string, StringValues>();
                    FormCollection form = new FormCollection(formDict);
                    foreach (var item in formCollection)
                    {
                        var key = item.Key;
                        values = new string[item.Value.Count];
                        for (var i = 0; i < values.Length; i++)
                        {
                            values[i] = Decrypt(item.Value[i]);
                        }

                        formDict.Add(key, new StringValues(values));
                    }
                    _context.Request.Form = form;
                }
            }
        }
        private string Decrypt(string item)
        {
            if (string.IsNullOrWhiteSpace(item)) return item;

            if (item.Length <= 1) return item;

            return item.Substring(1);
        }

        /// <summary>
        /// 验证请求参数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task Verify()
        {
            var arguments = new List<KeyValue>();
            var contentType = _context.Request.ContentType;
            
            if (contentType.ToLower().StartsWith("application/x-www-form-urlencoded"))
            {
                foreach (var item in _context.Request.Form)
                {
                    foreach (var value in item.Value)
                    {
                        arguments.Add(new KeyValue { Key = item.Key.ToLower(), Value = value });
                    }
                }
            }
            else if (contentType.ToLower().StartsWith("application/json"))
            {
                var json = "";
                using (var reader = new StreamReader(_context.Request.Body, Encoding.UTF8))
                {
                    json = reader.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var token = JsonConvert.DeserializeObject(json) as JToken;
                        arguments = QueryJson(token).Result;
                    }
                }
            }

            //验证sign,timestamp是否存在,且sign与timestamp只存在一个
            var sign = arguments.Find(p => p.Key == SIGN_KEY)?.Value;
            var timestamp = arguments.Find(p => p.Key == TIME_STAMP)?.Value;
            if (string.IsNullOrWhiteSpace(sign) && arguments.Count > 0)
            {
                throw new InvalidOperationException(Resource.ResourceManager.GetString("NOT_FOUND_SIGN"));
            }
            if(string.IsNullOrWhiteSpace(timestamp))
            {
                throw new InvalidOperationException(Resource.ResourceManager.GetString("TIME_STAMP_NOT_FOUND"));
            }
            if (arguments.Count(p => p.Key == SIGN_KEY) > 1 || arguments.Count(p => p.Key == timestamp) > 1)
            {
                throw new InvalidOperationException(Resource.ResourceManager.GetString("SIGN_TOO_Much_Value"));
            }
            arguments.RemoveAll(p => p.Key == SIGN_KEY);
            if (arguments.Count == 0) { return; }
            
            //排序，如果key不等，则按key从小到大，否则根据value从小到大排序
            arguments.Sort(new Comparison<KeyValue>((KeyValue value1, KeyValue value2) =>
            {
                var result = string.Compare(value1.Key, value2.Key);
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return string.Compare(value1.Value, value2.Value);
                }
            }));
            await Verify(arguments, sign, timestamp);
        }
        private Task<List<KeyValue>> QueryJson(JToken token)
        {
            var result = new List<KeyValue>();
            if (token.GetType() == typeof(JContainer))
            {
                foreach (var item in (JContainer)token)
                {
                    result.AddRange(QueryJson(item).Result);
                }
            }
            else {
                foreach (JProperty pop  in token)
                {
                    if (pop.Value.GetType() == typeof(JContainer))
                    {
                        foreach (var item in (JContainer)pop.Value)
                        {
                            result.AddRange(QueryJson(item).Result);
                        }
                    }
                    else if (pop.Value.HasValues)
                    {
                        result.AddRange(QueryJson(pop.Value).Result);
                    }
                    else
                    {
                        result.Add(new KeyValue { Key = pop.Name, Value = pop.Value.ToString() });
                    }
                }
            }

            return Task.FromResult(result);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="sortedArguments"></param>
        /// <param name="sign"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        private async Task Verify(List<KeyValue> sortedArguments, string sign, string timestamp)
        {
            if (!timestamp.IsNumber())
                throw new ArgumentException(Resource.ResourceManager.GetString("TIME_STAMP_NOT_FOUND"), nameof(timestamp));

            //验证时间戳
            var currTimestamp = DateTime.UtcNow.Timestamp();
            var clientTimestamp = long.Parse(timestamp);
            if (Math.Abs(currTimestamp - clientTimestamp) > TIME_STAMP_DIFF)
                throw new ArgumentException(Resource.ResourceManager.GetString("TIME_STAMP_INVALID"), nameof(timestamp));


            StringBuilder content = new StringBuilder();
            sortedArguments.ForEach(p =>
            {
                content.Append(p.Value);
            });
            var currSign = content.ToString().GetMD5(_options.AppId);
            if (currSign != sign)
                throw new ArgumentException(Resource.ResourceManager.GetString("SIGN_ERROR"), nameof(sign));
            
        }
    }

    public class KeyValue
    {
        public string Value { get; set; }
        public string Key { get; set; }

        public override int GetHashCode()
        {
            return $"{Key}={Value}".GetHashCode();
        }
    }
}
