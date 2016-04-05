/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ColumnPermission.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-21 17:06:40
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
    /// 可授权表的列权限配置
    /// </summary>
    public class ColumnPermission:IEntity<ColumnPermission>
    {
        /// <summary>
        /// 列Id
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string ColumnId { get; set; }

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
        public int RelationType { get; set; }

        /// <summary>
        /// 权限控制 1:可查询,2:可显示，4:可编辑,8:禁止查询,16:禁止显示,32:禁止编辑,多个值时求和
        /// </summary>
        [Required]
        public int Properties { get; set; }
    }
}
