/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ActivityResource.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-22 21:07:35
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission
{
    public class ActivityResource:IEntity<ActivityResource>
    {
        /// <summary>
        /// 资源Id
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string ResourceId { get; set; }

        /// <summary>
        /// 操作Id
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string ActivityId { get; set; }
    }
}
