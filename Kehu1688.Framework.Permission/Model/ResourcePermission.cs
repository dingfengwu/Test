/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Permission.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-21 13:37:04
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
    /// 资源权限
    /// </summary>
    public class ResourcePermission:IEntity<ResourcePermission>
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string ResourceId { get; set; }

        /// <summary>
        /// 授权主体Id,包括Role,User,Position,
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string RelationId { get; set; }

        /// <summary>
        /// 相关类型,0:用户,1:角色,3:职务
        /// </summary>
        [Required]
        public int RelationType { get; set; }

        /// <summary>
        /// 资源权限
        /// </summary>
        [Required]
        public int Properties { get; set; }
    }
}
