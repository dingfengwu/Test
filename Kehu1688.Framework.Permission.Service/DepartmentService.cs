/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DepartmentService.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 16:58:34
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Kehu1688.Framework.Store;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class DepartmentService: EntityFrameworkRepository<DepartmentService,Department>,IDomainService
    {
        public DepartmentService(ApplicationDbContext dbContext,ILoggerFactory logger):base(dbContext, logger)
        {

        }

    }
}
