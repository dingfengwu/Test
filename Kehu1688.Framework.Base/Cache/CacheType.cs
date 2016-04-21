/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：CacheType.cs
// 文件功能描述：
// CacheType枚举，用于确定缓存模块所属类型
//
// 创建人  ：WZJ
// 创建日期：2016-04-21 15:42:00
//----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base.Cache
{
    public enum CacheType
    {
        None = -1,
        Defualt = 0,
        WebCacha = 1,
        Redis = 2,
        MemCache = 3,
        File= 4,
        Xml = 5,
        Cloud_Redis = 6,
        Cloud_MemCache=7

    }
}
