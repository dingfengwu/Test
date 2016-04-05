/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RoleManagerExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-17 10:47:02
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Store;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleService:RoleManager<Role>, IDomainService
    {
        public RoleService(ApplicationRoleStore store,
            IEnumerable<IRoleValidator<Role>> validator,
            ILookupNormalizer normalizer,
            IdentityErrorDescriber errorDescriber,
            ILogger<RoleService> logger,
            IHttpContextAccessor accessor
            )
            :base(store,validator, normalizer, errorDescriber,logger, accessor)
        {

        }
    }
}
