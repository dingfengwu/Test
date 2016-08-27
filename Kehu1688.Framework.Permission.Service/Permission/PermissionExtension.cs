/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：PermissionExtension.cs
// 文件功能描述：
// 授权扩展类
//
// 创建人  ：WDF
// 创建日期：2016-04-12 15:39:34
//----------------------------------------------------------------*/



using Kehu1688.Framework.Config;
using Kehu1688.Framework.Permission.Service;
using Kehu1688.Framework.Store;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kehu1688.Framework.Permission.Service
{
    public static class PermissionExtension
    {
        /// <summary>
        /// 增加授权服务
        /// </summary>
        /// <param name="@this"></param>
        public static IServiceCollection AddPermission(this IServiceCollection @this)
        {
            @this.AddSingleton<PermissionService>();
            @this.AddSingleton<OperateLogService>();
            @this.AddSingleton<RoleService>();
            @this.AddSingleton<UserService>();
            @this.AddSingleton<ApplicationUserStore>();
            @this.AddSingleton<ApplicationRoleStore>();
            @this.AddSingleton<DepartmentService>();
            @this.AddSingleton<EntityFrameworkRepository>();
            @this.AddSingleton(typeof(EntityFrameworkRepository<,>));

            @this.AddSingleton<RightAuthorize>();
            
            return @this;
        }

        public static void UseRightHandler(this IApplicationBuilder @this,List<RightHandler<RightOption>> handlers)
        {
            var rightAuthorize = FrameworkConfig.IocConfig.Resolve<RightAuthorize>();
            var sourceHandlers = rightAuthorize.Handlers;
            var findlHandlers = new List<IRightHandler<RightOption>>();
            findlHandlers.AddRange(handlers);
            if (sourceHandlers != null && sourceHandlers.Count > 0)
                findlHandlers.AddRange(sourceHandlers);
            findlHandlers.OrderBy(p => p.Option.Order);
            for (var i = 0; i < findlHandlers.Count; i++)
            {
                if (i < findlHandlers.Count - 1)
                {
                    if (findlHandlers[i].Option.Order == findlHandlers[i + 1].Option.Order)
                    {
                        throw new InvalidOperationException("order of right handler repeat");
                    }
                }
            }
            
            foreach (var handler in handlers)
            {
                rightAuthorize.RegisterHandler(handler);
            }
        }
    }
}
