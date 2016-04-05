/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Department.cs
// 文件功能描述：
// 部门
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
    /// 部门
    /// </summary>
    public class Department:IEntity<Department>
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        [Key]
        [MaxLength(32)]
        public string Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 部门类型(0:公司,1:部门,2:小组)
        /// </summary>
        [Required]
        public int DepartmentType { get; set; }

        /// <summary>
        /// 父级部门
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string ParentId { get; set; }
    }
}
