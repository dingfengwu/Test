/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DefaultPermissionAuthorization.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-08 10:34:54
//----------------------------------------------------------------*/



using Microsoft.AspNet.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class DefaultPermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override void Handle(AuthorizationContext context, PermissionRequirement requirement)
        {
            //to do :验证权限
            if (context.HasFailed) return;

            throw new Exception("ssss");

            context.Succeed(requirement);
        }
    }
}
