/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：AuditFlow.cs
// 文件功能描述：
// 审核流实体类
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
    public class AuditFlow : IEntity<AuditFlow>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 策略id
        /// </summary>
        public string StrategyId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 审核流名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 转出ID
        /// </summary>
        public string NextId { get; set; }
        /// <summary>
        /// 转出路由
        /// </summary>
        public string NextRoute { get; set; }
        /// <summary>
        /// 会签选项
        /// </summary>
        public string JointlySign { get; set; }
        /// <summary>
        /// 会签意见
        /// </summary>
        public string SignContent { get; set; }
        /// <summary>
        /// 强制转交
        /// </summary>
        public int ForceTransfer { get; set; }
        /// <summary>
        /// 强制转交对象
        /// </summary>
        public string TransferObject { get; set; }
        /// <summary>
        /// 办理时限
        /// </summary>
        public string HandingTime { get; set; }
        /// <summary>
        /// 回退选择
        /// </summary>
        public DateTime FallBackOption { get; set; }
        /// <summary>
        /// 公共附件
        /// </summary>
        public string CommonComponent { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AuditMam { get; set; }
        /// <summary>
        /// 是否允许反审核
        /// </summary>
        public bool IsReAudit { get; set; }
        /// <summary>
        ///  反审核人
        /// </summary>
        public string ReAuditMan { get; set; }
        /// <summary>
        /// 是否允许委托
        /// </summary>
        public bool IsEntrust { get; set; }  
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }


    }
}
