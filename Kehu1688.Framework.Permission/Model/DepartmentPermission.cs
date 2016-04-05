/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RangePermission.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-21 15:32:00
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
    /// 部门权限
    /// </summary>
    public class DepartmentPermission : IEntity<DepartmentPermission>
    {
        /// <summary>
        /// 部门
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 授权主体Id,包括Role,User
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string RelationId { get; set; }

        /// <summary>
        /// 相关类型,0:用户,1:角色
        /// </summary>
        [Required]
        [MaxLength(32)]
        public int RelationType { get; set; }
    }
}
