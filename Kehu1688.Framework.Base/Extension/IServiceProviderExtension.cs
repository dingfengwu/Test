/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IServiceProviderExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-16 18:53:18
//----------------------------------------------------------------*/



using System;

namespace Kehu1688.Framework.Base
{
    public static class IServiceProviderExtension
    {
        public static T GetService<T>(this IServiceProvider provider) where T :class
        {
            if(provider==null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return provider.GetService(typeof(T)) as T;
        }
    }
}
