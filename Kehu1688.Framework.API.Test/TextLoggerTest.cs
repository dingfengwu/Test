/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：TextLoggerTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 14:26:58
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Kehu1688.Framework.API.Test
{
    public class TextLoggerTest
    {
        [Fact]
        public void TestTextLogger()
        {
            LoggerFactory factory = new LoggerFactory();
            factory.AddProvider(new TextLoggerProvider(options =>
            {
                options.LoggerPath = @"F:\框架\Kehu1688.Framework\Logs";
            }));
            var logger=factory.CreateLogger("Test");

            logger.LogVerbose(0, "Test Verbose");
            logger.LogWarning(0, "Test Warning");
            logger.LogError(0, "Test Error");

        }
    }
}
