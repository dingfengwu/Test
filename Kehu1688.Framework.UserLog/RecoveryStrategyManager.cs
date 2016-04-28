/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RecoveryStrategyManager.cs
// 文件功能描述：
// 用户日志恢复策略管理类
// 用于管理用户日志的恢复策略
// 包含策略的读取、策略的编辑、策略的执行三个方面
//
// 创建人  ：WZJ
// 创建日期：2016-04-23 10:40:00
//----------------------------------------------------------------*/

using Kehu1688.Framework.Config;
using Kehu1688.Framework.Permission.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.UserLog
{
    public class RecoveryStrategyManager
    {
        private LogRecoveryStrategyService content;

        public RecoveryStrategyManager()
        {
            content = FrameworkConfig.IocConfig.Resolve<LogRecoveryStrategyService>();
        }

        /// <summary>
        /// 恢复策略执行器
        /// </summary>
        public bool Performer(Permission.Model.UserLog userlog)
        {            
            return false;
        }

        /// <summary>
        /// 恢复策略读取器
        /// </summary>
        public List<Permission.Model.LogRecoveryStrategy> Reader()
        {
            return content.Find().ToList<Permission.Model.LogRecoveryStrategy>();
        }

        /// <summary>
        /// 恢复策略编写器
        /// </summary>
        public void Writer(Permission.Model.LogRecoveryStrategy model)
        {
            content.AddSave(model);
        }

        /// <summary>
        /// 恢复策略编写器
        /// </summary>
        public void Writer(List<Permission.Model.LogRecoveryStrategy> recoverylist)
        {
            var s = content.BulkAdd(recoverylist);
            s.Start();
            content.SaveChanges();
        }
    }
}
