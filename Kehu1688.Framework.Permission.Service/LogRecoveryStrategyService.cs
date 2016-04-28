/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：LogRecoveryStrategyService.cs
// 文件功能描述：
// 日志恢复策略服务
//
// 创建人  ：WZJ
// 创建日期：2016-04-25 16:27:02
//----------------------------------------------------------------*/

using Kehu1688.Framework.Base;
using Kehu1688.Framework.Store;
using Kehu1688.Framework.Permission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Kehu1688.Framework.Permission.Service
{
    public class LogRecoveryStrategyService : EntityFrameworkRepository<LogRecoveryStrategyService, LogRecoveryStrategy>, IDomainService
    {
        public LogRecoveryStrategyService(ApplicationDbContext dbContext, ILoggerFactory logger) : base(dbContext, logger)
        {
        }

        
    }
}
