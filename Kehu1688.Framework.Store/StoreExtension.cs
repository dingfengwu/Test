/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：StoreExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-13 14:35:15
//----------------------------------------------------------------*/



using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    public static class StoreExtension
    {
        public static void AddStore(this IServiceCollection @this)
        {
            @this.AddScoped(typeof(EntityFrameworkRepositoryBase<>));
            @this.AddScoped(typeof(EntityFrameworkRepository));
            @this.AddScoped(typeof(EntityFrameworkRepository<,>));
            @this.AddScoped(typeof(EntityFrameworkRepository<>));

            @this.AddTransient(typeof(DbHelper), typeof(SqlHelper));
        }
    }
}
