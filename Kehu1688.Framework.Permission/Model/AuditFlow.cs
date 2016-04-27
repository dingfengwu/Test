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
        public long id { get; set; }
        /// <summary>
        /// 策略id
        /// </summary>
        public int strategyId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 父级id，默认为0
        /// </summary>
        public long parentId { get; set; }
        /// <summary>
        /// 祖先id，默认为0
        /// </summary>
        public long ancestorId { get; set; }
        /// <summary>
        /// 审核轮次
        /// </summary>
        public int rountNumber { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string applicant { get; set; }
        /// <summary>
        /// 申请说明内容
        /// </summary>
        public string applyContext { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime createTime { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string auditor { get; set; }
        /// <summary>
        /// 审核说明内容
        /// </summary>
        public string auditContext { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime auditTime { get; set; }
        /// <summary>
        /// 是否终结审核，快速判断
        /// </summary>
        public bool isfinish { get; set; }

        #region 方法
        /// <summary>
        /// 设置申请人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SetApplicant(OperationManViewModel model)
        {
            try
            {
                applicant = model.ToJson();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置审核人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SetAuditor(OperationManViewModel model)
        {
            try
            {
                auditor = model.ToJson();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取申请人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperationManViewModel GetApplicant()
        {
            try
            {
                return CommonExtenstion.ToJson<OperationManViewModel>(applicant);                
            }
            catch
            {
                return new OperationManViewModel();
            }
        }

        /// <summary>
        /// 获取审核人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperationManViewModel GetAuditor()
        {
            try
            {
                return CommonExtenstion.ToJson<OperationManViewModel>(auditor);
            }
            catch
            {
                return new OperationManViewModel();
            }
        }
        #endregion
    }
}
