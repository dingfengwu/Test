/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Resource.cs
// 文件功能描述：
// 资源
//
// 创建人  ：WDF
// 创建日期：2016-03-08
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
    /// 资源
    /// </summary>
    public class Resource:IEntity<Resource>
    {
        /// <summary>
        /// 资源Id
        /// </summary>
        [Key]
        [MaxLength(32)]
        public string Id { get; set; }

        /// <summary>
        /// 资源Code
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string ResourceCode { get; set; }

        /// <summary>
        /// 资源名
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [Required]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 菜单Id
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string MenuId { get; set; }
        
        /// <summary>
        /// 资源的所有操作
        /// </summary>
        public ICollection<ActivityResource> Activities { get; set; } = new List<ActivityResource>();
    }
}
