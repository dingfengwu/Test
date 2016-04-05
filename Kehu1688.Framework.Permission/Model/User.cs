/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Account.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-21 9:58:14
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User:IdentityUser,IEntity<User>
    {
        /// <summary>
        /// Token
        /// </summary>
        public string UserToken { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string UserSecret { get; set; }
    }
}
