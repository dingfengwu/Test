using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Kehu1688.Framework.Middleware;
using System.Text;
using Kehu1688.Framework.Base;
using System.Net.Http;
using System.Net;


namespace Kehu1688.Framework.API.Test
{
    //https://channel9.msdn.com/Series/Visual-Studio-2012-Premium-and-Ultimate-Overview-CHS/Visual-Studio-Ultimate-2012-Improving-quality-with-unit-tests-and-fakes-CHS
    public class SecurityMiddlewareTest
    {
        public SecurityMiddlewareTest()
        {

        }

        //[Theory]
        //[InlineData(-1)]
        //[InlineData(0)]
        //[InlineData(1)]
        //public void TestMethod(int i)
        //{
        //    Assert.True(Math.Abs(i)<=1);
        //}

        [Fact]
        public void TestMiddleware()
        {
            var clientId = "self";
            TestServer server = TestServer.Create(app =>
            {
                app.UseSecurity(new SecurityMiddlewareOption()
                {
                    AllowArgumentEncrypt = true,
                    AppId = clientId
                });
            });

            var arguments = "arg1=123&arg2=456&arg3=789&arg4=abc";
            arguments = GetEncryptString(arguments, clientId).Result;
            var list = ConvertArguments(arguments).Result;
            var response = server.CreateClient().PostAsync("./Test", new FormUrlEncodedContent(list)).Result;
            Assert.True(response.StatusCode != HttpStatusCode.BadRequest);
        }

        private Task<List<KeyValuePair<string,string>>> ConvertArguments(string arguments)
        {
            var key = "";
            var value = "";
            var list = new List<KeyValuePair<string, string>>();
            foreach (var item in arguments.Split('&'))
            {
                key = item.Split('=')[0];
                value = item.Split('=')[1];
                list.Add(new KeyValuePair<string, string>(key, value));
            }
            return Task.FromResult<List<KeyValuePair<string, string>>>(list);
        }

        private Task<string> GetEncryptString(string arguments,string clientId)
        {
            if (arguments == null)
                throw new ArgumentNullException(nameof(arguments));

            var key = "";
            var value = "";
            StringBuilder content = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            var timestamp = DateTime.UtcNow.Timestamp();
            var list = new List<KeyValue>();
            var argArr = arguments.Split('&');
            foreach (var item in argArr)
            {
                key = item.Split('=')[0];
                value = item.Split('=')[1];

                list.Add(new KeyValue() { Key = key, Value = value });
            }
            list.Add(new KeyValue { Key = "timestamp", Value = timestamp.ToString() });

            //排序
            list.Sort(new Comparison<KeyValue>((KeyValue value1, KeyValue value2) =>
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
            list.ForEach(p =>
            {
                content.Append(p.Value);
                builder.Append($"{p.Key}={Encrypt(p.Value)}&");
            });

            var sign = content.ToString().GetMD5(clientId);
            builder.Append($"sign={Encrypt(sign)}");

            return Task.FromResult(builder.ToString());
        }

        private string Encrypt(string str)
        {
            return "!" + str;
        }
    }
}
