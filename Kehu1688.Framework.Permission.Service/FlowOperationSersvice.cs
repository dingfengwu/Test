/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：FlowOperationSersvice.cs
// 文件功能描述：
// 审核流操作记录服务
//
// 创建人  ：WZJ
// 创建日期：2016-04-29 10:26:02
//----------------------------------------------------------------*/


using Kehu1688.Framework.Base;
using Kehu1688.Framework.Permission.Model;
using Kehu1688.Framework.Store;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class FlowOperationSersvice : EntityFrameworkRepository<FlowOperationSersvice, FlowOperation>, IDomainService
    {
        public FlowOperationSersvice(ApplicationDbContext dbContext, ILoggerFactory logger) : base(dbContext, logger)
        {
        }
    }
}
