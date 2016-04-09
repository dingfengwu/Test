/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DefaultModule.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-09 20:51:00
//----------------------------------------------------------------*/



using Autofac;
using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Permission.Service;
using Microsoft.Extensions.Configuration;

namespace Kehu1688.Framework.DI
{
    public class DefaultModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册域服务
            builder.RegisterType<PermissionService>().SingleInstance();
            builder.RegisterType<RoleService>().SingleInstance();
            builder.RegisterType<UserService>().SingleInstance();
            builder.RegisterType<ApplicationUserStore>().SingleInstance();
            builder.RegisterType<ApplicationRoleStore>().SingleInstance();

            base.Load(builder);
        }
    }
}
