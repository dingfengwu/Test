/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：CacheReturnData.cs
// 文件功能描述：
// 缓存模块返回数据
//
// 创建人  ：WZJ
// 创建日期：2016-04-04 9:12:00
//----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Cache
{
    public class CacheReturnData<T>
    {
        public bool reult { get; set; }
        public T data { get; set; }
    }
}
