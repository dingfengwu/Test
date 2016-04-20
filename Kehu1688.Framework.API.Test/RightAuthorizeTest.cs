/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightAuthorizeTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-15 11:04:16
//----------------------------------------------------------------*/

using Microsoft.AspNet.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Kehu1688.Framework.API.Test
{
    public class RightAuthorizeTest
    {
        TestHelper _testHelper;
        TestServer _server;

        public RightAuthorizeTest()
        {
            _testHelper = new TestHelper();
            _server = _testHelper.CreateServer();
        }

        [Fact]
        public async void AuthroizeOperateRight()
        {
            var response=await _testHelper.RequestContent(_server, "./Test/Test", new List<KeyValuePair<string, string>>());

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

            }
            else
            {
                var body = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(body);
                throw new Exception(body);
            }
        }
    }
}
