/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：PermissionAuthroizeAttribute.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-08 13:38:37
//----------------------------------------------------------------*/



using Microsoft.AspNet.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class PermissionAuthroizeAttribute:AuthorizeAttribute
    {
        public PermissionAuthroizeAttribute(string policy) : base(policy)
        {
            ActiveAuthenticationSchemes = "Bearer";
        }

        public PermissionAuthroizeAttribute() : base()
        {
            ActiveAuthenticationSchemes = "Bearer";
        }
        
        /// <summary>
        /// 操作key
        /// </summary>
        public string Operate { get; set; }

        /// <summary>
        /// 模块key
        /// </summary>
        public string Module { get; set; }
    }
}
