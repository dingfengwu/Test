/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：AuditStrategy.cs
// 文件功能描述：
// 审核策略实体类
//
// 创建人  ：WZJ
// 创建日期：2016-04-27 10:20:00
//----------------------------------------------------------------*/


using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Model
{
    public class AuditStrategy : IEntity<AuditStrategy>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 来源名称
        /// </summary>
        public string FromName { get; set; }
        /// <summary>
        /// 来源id
        /// </summary>
        public string FromId { get; set; }
        /// <summary>
        /// 策略名称
        /// </summary>
        public string StrategyName { get; set; }
        /// <summary>
        /// 策略类型
        /// </summary>
        public string StrategyType { get; set; }
        /// <summary>
        /// 审核最大轮数
        /// </summary>
        public int MaxRountNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
    }
}
