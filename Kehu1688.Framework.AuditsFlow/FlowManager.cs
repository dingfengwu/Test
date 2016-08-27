/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：FlowManager.cs
// 文件功能描述：
// 审核流管理器
//
// 创建人  ：WZJ
// 创建日期：2016-04-23 11:50:00
//----------------------------------------------------------------*/

using Kehu1688.Framework.Config;
using Kehu1688.Framework.Permission.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.AuditsFlow
{ 
    public class FlowManager
    {
        /// <summary>
        /// 审核流服务
        /// </summary>
        protected AuditFlowService afcontent;
        /// <summary>
        /// 审核策略服务
        /// </summary>
        protected AuditStrategyService ascontent;
        /// <summary>
        /// 流操作信息
        /// </summary>
        protected FlowOperationSersvice foscontent;

        public FlowManager()
        {
            afcontent = FrameworkConfig.IocConfig.Resolve<AuditFlowService>();
            ascontent = FrameworkConfig.IocConfig.Resolve<AuditStrategyService>();
            foscontent = FrameworkConfig.IocConfig.Resolve<FlowOperationSersvice>();
        }

        #region 审核流
        public List<Permission.Model.AuditFlow> GetAuditFlow()
        {
            return afcontent.Find().ToList();
        }

        public void AddAuditFlow(Permission.Model.AuditFlow model)
        {
            afcontent.AddSave(model);
        }

        public void AddAuditFlow(List<Permission.Model.AuditFlow> list)
        {
            var task = afcontent.BulkAdd(list);
            task.Start();
        }
        #endregion

        #region 审核策略
        public List<Permission.Model.AuditStrategy> GetAuditStrategy()
        {
            return ascontent.Find().ToList();
        }

        public void AddAuditStrategy(Permission.Model.AuditStrategy model)
        {
            ascontent.AddSave(model);
        }

        public void AddAuditStrategy(List<Permission.Model.AuditStrategy> list)
        {
            var task = ascontent.BulkAdd(list);
            task.Start();
        }

        #endregion
        
        #region 审核流操作记录
        public List<Permission.Model.FlowOperation> GetFlowOperation()
        {
            return foscontent.Find().ToList();
        }

        public void AddFlowOperation(Permission.Model.FlowOperation model)
        {
            foscontent.AddSave(model);
        }

        public void AddFlowOperation(List<Permission.Model.FlowOperation> list)
        {
            var task = foscontent.BulkAdd(list);
            task.Start();
        }
        #endregion

    }
}

 
 