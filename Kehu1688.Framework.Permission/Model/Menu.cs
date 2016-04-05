/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Menu.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-21 10:26:43
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu:IEntity<Menu>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [MaxLength(32)]
        public string Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        [Display(Description ="菜单名称")]
        public string Name { get; set; }
    }
}
