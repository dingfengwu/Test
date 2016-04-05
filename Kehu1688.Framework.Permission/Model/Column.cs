/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Column.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-21 16:44:34
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
    /// 表及视图的列
    /// </summary>
    public class Column:IEntity<Column>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [MaxLength(32)]
        public string Id { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 中文(外语)列名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FLName { get; set; }

        /// <summary>
        /// 是否可以进行权限控制,要控制字段权限时，此字段为true 
        /// </summary>
        [Required]
        public bool Authorize { get; set; } = false;
    }
}
