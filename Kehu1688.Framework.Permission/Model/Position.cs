/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Position.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-21 12:01:49
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
    /// 职务
    /// </summary>
    public class Position:IEntity<Position>
    {
        /// <summary>
        /// 职务Id
        /// </summary>
        [Key]
        [MaxLength(32)]
        public string Id { get; set; }

        /// <summary>
        /// 职务名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
