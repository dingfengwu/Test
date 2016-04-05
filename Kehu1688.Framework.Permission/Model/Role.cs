/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Rolw.cs
// 文件功能描述：
// 角色管理
//
// 创建人  ：WDF
// 创建日期：2016-03-08
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role: IdentityRole, IEntity<Role>
    {
        /// <summary>
        /// 是否为系统角色
        /// </summary>
        [Required]
        public bool IsSysRole { get; set; } = false;

        /// <summary>
        /// 是否可用
        /// </summary>
        [Required]
        public bool Enabled { get; set; } = true;
    }
}
