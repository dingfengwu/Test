/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OAuthTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-29 11:07:38
//----------------------------------------------------------------*/



using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Permission.Service;
using Kehu1688.Framework.Store;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.TestHost;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Logging;

namespace Kehu1688.Framework.API.Test
{
    public class OAuthTest
    {
        TestServer _server;
        Startup _start;

        public OAuthTest()
        {
            _server = CreateServer();
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
        }

        [Fact]
        public async void TestApi()
        {
            var accessToken = await GetAccessToken();

            var token = JsonConvert.DeserializeObject(accessToken) as JToken;
            var tokenStr = token.SelectToken("access_token").ToString();

            var list = new List<KeyValuePair<string, string>>();
            var content = new FormUrlEncodedContent(list);
            var client = _server.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenStr}");
            var response= await client.PostAsync("./Account/Test", content);
            if (response.StatusCode !=HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
        
        [Fact]
        public async Task<string> GetAccessToken()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("username","\"ADMIN001\""));
            list.Add(new KeyValuePair<string, string>("password", "\"123456\""));
            list.Add(new KeyValuePair<string, string>("grant_type", "password"));
            var response = await _server.CreateClient().PostAsync("./Token", new FormUrlEncodedContent(list));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            throw new Exception("error");
        }

        private TestServer CreateServer()
        {
            _start = new Startup(null);
            TestServer server = TestServer.Create((IApplicationBuilder builder) =>
            {
                var env = builder.ApplicationServices.GetService<IHostingEnvironment>();
                var logger = builder.ApplicationServices.GetService<ILoggerFactory>();
                _start.Configure(builder, env, logger);
            },
                _start.ConfigureServices);
            return server;
        }
    }
}
