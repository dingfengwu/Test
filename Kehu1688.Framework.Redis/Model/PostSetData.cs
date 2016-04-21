/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：PostSetData.cs
// 文件功能描述：
// Redis参数设置类 属性：app key value outtime
//
// 创建人  ：WZJ
// 创建日期：2016-04-21 15:42:00
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Redis.Model
{
    public class PostSetData<TModel>:PostSetTimeData
    {
        public TModel value { get; set; }

        
            
    }
}
