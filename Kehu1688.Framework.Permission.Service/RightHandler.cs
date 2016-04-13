/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightHandler.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-13 17:33:49
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class RightHandler : IRightHandler
    {
        public Task<bool> Authorize(string moduleKey, string opKey, string entityId)
        {
            
        }
    }
}
