/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：EntityframeworkRepositoryTest.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 19:27:57
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Kehu1688.Framework.Config;
using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Kehu1688.Framework.Permission.Model;

namespace Kehu1688.Framework.API.Test
{
    public class EntityframeworkRepositoryTest
    {
        [Fact]
        public async void TestBlukInsert()
        {
            var testHelper = new TestHelper();
            testHelper.CreateServer();
            var loggerFactory = testHelper.Builder.ApplicationServices.GetService<ILoggerFactory>();
            using (ApplicationDbContext context = FrameworkConfig.IocConfig.Resolve<ApplicationDbContext>())
            {
                var entities = new List<Department>();
                var idGenerator = FrameworkConfig.IocConfig.Resolve<IdGenerator>();
                EntityFrameworkRepository<Department> rep = new EntityFrameworkRepository<Department>(context, loggerFactory);

                for (var i = 0; i < 1000000; i++)
                {
                    entities.Add(new Department
                    {
                        Id = idGenerator.GuidToLongId().ToString(),
                        DepartmentType = 1,
                        Name = "Dpt" + i.ToString(),
                        ParentId=""
                    });
                }

#if DNX451 || NET451
                await rep.BulkAdd(entities);
#else
                throw new NotSupportedException("this runtime not support");
#endif
            }
        }

        [Fact]
        public void TestNoPropertyEntity()
        {
            var testHelper = new TestHelper();
            testHelper.CreateServer();
            var loggerFactory = testHelper.Builder.ApplicationServices.GetService<ILoggerFactory>();
            using (ApplicationDbContext context = FrameworkConfig.IocConfig.Resolve<ApplicationDbContext>())
            {
                context.Set<TableView>().Add(new TableView
                {
                    Id = IdGenerator.Instance.GuidToLongId().ToString(),
                    Authorize=true,
                    FLName="测试",
                    Name="Test"
                });
                context.SaveChanges();
            }
        }
    }
}
