/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Permission.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-08-27 12:01:29
//----------------------------------------------------------------*/



using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store.DbContext
{
    public partial class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        /// <summary>
        /// 操作
        /// </summary>
        public DbSet<Activity> Activities { get; set; }
    }
}
