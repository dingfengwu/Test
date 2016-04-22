/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RedisWebConnection.cs
// 文件功能描述：
// 自制的 Redis 缓存服务器Web API 模块连接和调用
//
// 创建人  ：WZJ
// 创建日期：2016-04-12 14:13:00
//----------------------------------------------------------------*/

using Kehu1688.Framework.Base;
using Kehu1688.Framework.Base.Cache;
using Kehu1688.Framework.Base.Http;
using Kehu1688.Framework.Redis.Model;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Redis
{
    public class RedisWebConnection : CacheModule
    {
        public RedisWebConnection(string host = "localhost", int port = 80, string password = null, long db = 0) : base(host, port, password, db)
        {
            Host = host;
            Port = port;
            cacheType = CacheType.Cloud_Redis;
        }

        protected string GetClient()
        {
#if DNX451 || NET451
            return $"{Host}:{Port}/Cache/";
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif            
        }

        
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value">不容许为null</param>
        /// <returns></returns>
        public override bool Set<T>(string key, T value)
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "Set";
            PostSetData<T> postdata = new PostSetData<T>() { app="",key=key,value=value,outtime=1200};
            var r = Http.HttpPost(url,postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if(rd.result.IndexOf("sussecc")>=0)
                return true;
            else
                return false;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif

        }


        public override bool Set<T>(string key, T value, DateTime time)
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "Set";
            PostSetData<T> postdata = new PostSetData<T>() { app = "", key = key, value = value,outtime= (int)(time.Timestamp()-DateTime.Now.Timestamp())};
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0)
                return true;
            else
                return false;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 不带值则删除key对应的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool Set(string key)
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "Delete";
            string[] keys = { key };
            PostDelData postdata = new PostDelData() { app = "", key = keys };
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0)
                return true;
            else
                return false;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 根据key获取缓存值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public override T Get<T>(string key)
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "Get";
            PostGetandTimeData postdata = new PostGetandTimeData() { app = "", key = key, delayouttime="600" };
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0)
                return CommonExtenstion.ToJson<T>(rd.data);
            else
                return default(T);
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool Exists(string key)
        {
#if DNX451 || NET451

            var url = GetClient();
            url = url + "Exists";
            PostGetData postdata = new PostGetData() { app = "", key = key };
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0 && rd.data.IndexOf("true") >= 0)
                return true;
            else
                return false;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 根据key获取缓存记录id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override long KeyId(string key)
        {
            throw new Exception("not support this method");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override long KeysNum()
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "KeysNum";
            PostData postdata = new PostData() { app = ""};
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0 )
                return Convert.ToInt64(rd.data);
            else
                return 0;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 获取服务器版本号
        /// </summary>
        /// <returns></returns>
        public override string ServerVersion()
        {
            var info = ServerInfo();
            return  info["redis_version"];
        }

        public override void FlushAll()
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "FlushAll";
            PostData postdata = new PostData() { app = "" };
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        public override void FlushDB()
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "FlushDB";
            PostData postdata = new PostData() { app = ""  };
            var r = Http.HttpPost(url, postdata.ToJson());
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 根据key来删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override long Delete(params string[] key)
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "Delete";
            PostDelData postdata = new PostDelData() { app = "", key = key  };
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0)
                return Convert.ToInt64(rd.data);
            else
                return 0;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 设置生成时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public override bool Expire(string key, int s)
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "SetOutTime";
            PostSetTimeData postdata = new PostSetTimeData() { app = "", key = key,outtime=s };
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0)
                return true;
            else
                return false;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        public override long LPush(string key, byte[] s)
        {
            throw new Exception("not support this method");
        }

        public override  byte[] RPop(string key)
        {
            throw new Exception("not support this method");
        }

        public override  byte[] RPopLPush(string key)
        {
            throw new Exception("not support this method");
        }

        public override  byte[] RPopLPush(string fromkey, string tokey)
        {
            throw new Exception("not support this method");
        }

        /// <summary>
        /// 获取存在的Key的值
        /// </summary>
        /// <param name="pattern">
        /// KEYS * 匹配数据库中所有 key 。
        /// KEYS h?llo 匹配 hello ， hallo 和 hxllo 等。
        /// KEYS h*llo 匹配 hllo 和 heeeeello 等。
        /// KEYS h[ae]llo 匹配 hello 和 hallo ，但不匹配 hillo
        /// </param>
        /// <returns></returns>
        public override List<string> Keys(string pattern)
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "GetKeys";
            PostTryData postdata = new PostTryData() { app = "", pattern = pattern };
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0)
                return CommonExtenstion.ToJson<List<string>>(rd.data);
            else
                return new List<string>();            
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 获取key剩余生存时间，秒为单位
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override long TTL(string key)
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "GetKeys";
            PostGetData postdata = new PostGetData() { app = "", key= key};
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0)
                return CommonExtenstion.ToJson<long>(rd.data);
            else
                return -1;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 获取key剩余生成时间，毫秒为单位
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override long PTTL(string key)
        { 
            throw new Exception("not support this method");
 
        }

        /// <summary>
        /// 移动key-value到指定db内
        /// </summary>
        /// <param name="key"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override bool Move(string key, int db)
        {
            throw new Exception("not support this method");
        }

        /// <summary>
        /// 获取服务器信息
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> ServerInfo()
        {
#if DNX451 || NET451
            var url = GetClient();
            url = url + "ServerInfo";
            PostData postdata = new PostData() { app = "" };
            var r = Http.HttpPost(url, postdata.ToJson());
            var rd = CommonExtenstion.ToJson<ServerData>(r);
            if (rd.result.IndexOf("sussecc") >= 0)
                return CommonExtenstion.ToJson<Dictionary<string, string>>(rd.data);
            else
                return new Dictionary<string, string>();
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }
    }
}
