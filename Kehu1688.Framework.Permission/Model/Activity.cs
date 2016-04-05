/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Activity.cs
// 文件功能描述：
// 权限活动（操作）
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
    /// 活动(操作)
    /// </summary>
    public class Activity:IEntity<Activity>
    {
        /// <summary>
        /// 活动Id
        /// </summary>
        [Key]
        [MaxLength(32)]
        public string Id { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 活动编码
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string ActivityCode { get; set; }

        /// <summary>
        /// 操作的顺序
        /// </summary>
        [Required]
        public int Order { get; set; } = 0;
        
        /// <summary>
        /// 所能控制的所有资源
        /// </summary>
        public ICollection<ActivityResource> Resources { get; set; } = new List<ActivityResource>();
    }
}
