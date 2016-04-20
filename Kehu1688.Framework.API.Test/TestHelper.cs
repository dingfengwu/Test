/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：TestHelper.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-15 11:04:53
//----------------------------------------------------------------*/



using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kehu1688.Framework.API.Test
{
    public class TestHelper
    {
        public IApplicationBuilder Builder { get; private set; }

        public TestServer CreateServer()
        {
            var start = new Startup(null);
            TestServer server = TestServer.Create((IApplicationBuilder builder) =>
            {
                Builder = builder;
                var env = builder.ApplicationServices.GetService<IHostingEnvironment>();
                env.EnvironmentName = "Development";
                var logger = builder.ApplicationServices.GetService<ILoggerFactory>();
                start.Configure(builder, env, logger);
            },
                start.ConfigureServices);
            return server;
        }

        public async Task<string> GetAccessToken(TestServer server)
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("username", "\"ADMIN001\""));
            list.Add(new KeyValuePair<string, string>("password", "\"123456\""));
            list.Add(new KeyValuePair<string, string>("grant_type", "password"));
            var response = await server.CreateClient().PostAsync("./Token", new FormUrlEncodedContent(list));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject(body) as JToken;
                    var tokenStr = token.SelectToken("access_token").ToString();

                    return tokenStr;
                }
                catch (Exception ex)
                {
                    throw new Exception("format json fail", ex);
                }
            }
            throw new Exception("get access token fail");
        }

        public async Task<HttpResponseMessage> RequestContent(TestServer server,string address, List<KeyValuePair<string, string>> formValues)
        {
            var accessToken = await GetAccessToken(server);
            var content = new FormUrlEncodedContent(formValues);
            var client = server.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            var response = await client.PostAsync(address, content);
            return response;
        }

        public async Task<HttpResponseMessage> AnonymousRequestContent(TestServer server, string address, List<KeyValuePair<string, string>> formValues)
        {
            var content = new FormUrlEncodedContent(formValues);
            var client = server.CreateClient();
            var response = await client.PostAsync(address, content);
            return response;
        }
    }
}
