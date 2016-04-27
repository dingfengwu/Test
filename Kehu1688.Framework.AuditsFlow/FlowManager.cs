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

using Kehu1688.Framework.Permission.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.AuditsFlow
{ 
    public class FlowManager
    {
        protected AuditFlowService afcontent;
        protected AuditStrategyService asconrent;

        public List<Framework.Permission.Model.AuditFlow> GetAuditFlow()
        {
            return afcontent.Find().ToList();
        }

        public void AddAuditFlow()
        {

        }
    }
}

 
 