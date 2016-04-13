/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ApplicationRoleStore.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-18 11:53:53
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
    /// 角色存储
    /// </summary>
    public class ApplicationRoleStore:RoleStore<Role,ApplicationDbContext>
    {
        public ApplicationRoleStore(ApplicationDbContext context,IdentityErrorDescriber describer) 
            :base(context,describer)
        {

        }
    }
}
