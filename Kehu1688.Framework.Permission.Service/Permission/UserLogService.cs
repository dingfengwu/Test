/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：UserLogService.cs
// 文件功能描述：
// 用户日志服务
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
    public class UserLogService : EntityFrameworkRepository<UserLogService, UserLog>, IDomainService
    {
        public UserLogService(ApplicationDbContext dbContext, ILoggerFactory logger) : base(dbContext, logger)
        {
        }

        
    }
}
