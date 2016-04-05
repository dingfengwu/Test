/*----------------------------------------------------------------
// Copyright (C) 2013 Kehu1688
// 版权所有。
//
// 文件名：Entity.cs
// 文件功能描述：
// 所有实体的基类
//
// 创建人  ：WDF
// 创建日期：2016-03-08
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base
{
    public interface IEntity<TModel> where TModel: IEntity<TModel>
    {
        
    }
}
