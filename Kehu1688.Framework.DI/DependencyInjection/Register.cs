/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ServiceRegister.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-09 19:13:50
//----------------------------------------------------------------*/



using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kehu1688.Framework.DI
{
    public static class Register
    {
        static ContainerBuilder _builder;
        static Register()
        {
            _builder = new ContainerBuilder();
        }

        /// <summary>
        /// 注入容器
        /// </summary>
        public static IContainer Container{ get; private set; }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services">集成服务</param>
        public static void RegisterService(IServiceCollection services = null)
        {
            _builder.RegisterModule<DefaultModule>();
            _builder.Populate(services);
            Container=_builder.Build();
        }

        /// <summary>
        /// 返回指定服务
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>实例</returns>
        public static T Get<T>() => Container.Resolve<T>();

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>实例</returns>
        public static object Get(Type type) => Container.Resolve(type);
    }
}
