/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IocConfig.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-09 10:21:01
//----------------------------------------------------------------*/



using Kehu1688.Framework.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Config
{
    public class IocConfig
    {
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>实例</returns>
        public T Resolve<T>()
        {
            return Register.Get<T>();
        }

        /// <summary>
        /// 获取指定类型的实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>实例</returns>
        public object Resolve(Type type)
        {
            return Register.Get(type);
        }
    }
}
