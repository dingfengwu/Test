/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ReadWriteSplitTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-19 15:09:16
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Kehu1688.Framework.Config;
using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Permission.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Kehu1688.Framework.API.Test
{
    public class ReadWriteSplitTest
    {
        [Fact]
        public void TestReadWriteSplit()
        {
            var helper = new TestHelper();
            var server = helper.CreateServer();
            var dptSvr = FrameworkConfig.IocConfig.Resolve<DepartmentService>();
            var logger = FrameworkConfig.IocConfig.Resolve<ILoggerFactory>().CreateLogger(nameof(TestReadWriteSplit));
            var id = IdGenerator.Instance.GuidToLongId().ToString();
            dptSvr.Add(new Permission.Department
            {
                DepartmentType = 0,
                Id = id,
                Name = "Test8",
                ParentId = "0"
            });
            dptSvr.SaveChanges();

            Stopwatch stop = new Stopwatch();
            stop.Start();
            Department dpt = null;
            do
            {
                dpt = dptSvr.Find(p => p.Id == id).FirstOrDefault();
            } while (dpt == null);
            stop.Stop();
            
            logger.LogVerbose($"the time is {stop.ElapsedMilliseconds}ms");
            Assert.True(dpt != null);
        }
    }
}
