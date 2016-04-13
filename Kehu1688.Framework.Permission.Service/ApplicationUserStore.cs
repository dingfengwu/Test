/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：UserStore.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-18 11:33:56
//----------------------------------------------------------------*/



using Kehu1688.Framework.Store;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 用户存储
    /// </summary>
    public class ApplicationUserStore:UserStore<User, Role, ApplicationDbContext>
    {
        public ApplicationUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) 
            : base(context, describer)
        {

        }
    }
}
