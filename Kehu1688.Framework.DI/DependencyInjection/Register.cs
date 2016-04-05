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
        /// <param name="services"></param>
        public static void RegisterService(IServiceCollection services = null)
        {
            _builder.RegisterModule<DefaultModule>();
            foreach (var item in services)
            {
                //_builder.RegisterDecorator<IServiceProvider>(item, item, null);
            }
            Container=_builder.Build();
        }

        /// <summary>
        /// 返回指定服务
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static TService Get<TService>() => Container.Resolve<TService>();

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Get(Type type) => Container.Resolve(type);
    }
}
