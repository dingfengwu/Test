/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Table.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-21 16:34:19
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Model
{
    /// <summary>
    /// 表与视图
    /// </summary>
    public class TableView:IEntity<TableView>
    {
        /// <summary>
        /// 表Id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 中文(外语)表名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FLName { get; set; }

        /// <summary>
        /// 是否可以进行权限控制，要控制字段权限时，此字段为true
        /// </summary>
        [Required]
        public bool Authorize { get; set; } = false;
    }
}
