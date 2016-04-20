/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：PerformanceTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-16 9:34:43
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Kehu1688.Framework.API.Test
{
    public class PerformanceTest
    {
        [Fact]
        public void MutilRequest()
        {
            TestHelper testHelper = new TestHelper();
            var server=testHelper.CreateServer();

            var startTime = DateTime.Now;
            Console.WriteLine($"the request start time is {DateTime.Now}");
            var response2 = testHelper.AnonymousRequestContent(server, "./Test/ShortTest", new List<KeyValuePair<string, string>>());

            var response1=testHelper.AnonymousRequestContent(server,"./Test/LongTest",new List<KeyValuePair<string, string>>());

            if (response2.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"the second request completed time is {DateTime.Now}");
                Console.WriteLine(response2.Result.Content.ReadAsStringAsync());
            }

            if (response1.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"the first request completed time is {DateTime.Now}");
                Console.WriteLine(response1.Result.Content.ReadAsStringAsync());
            }
            var endTime = DateTime.Now;

            Assert.True((endTime - startTime).TotalSeconds < 40);
            
        }
    }
}
