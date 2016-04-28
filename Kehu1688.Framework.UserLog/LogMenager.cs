/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：LogMenager.cs
// 文件功能描述：
// 用户日志管理类
// 用于管理用户日志的恢复策略
// 包含日志读取、日志编辑、日志恢复执行三个方面
//
// 创建人  ：WZJ
// 创建日期：2016-04-23 10:40:00
//----------------------------------------------------------------*/


using Kehu1688.Framework.Permission.Service;
using Kehu1688.Framework.Permission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kehu1688.Framework.Config;

namespace Kehu1688.Framework.UserLog
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class LogMenager
    {
        /// <summary>
        /// UserLog  EF服务
        /// </summary>
        private UserLogService content;
        /// <summary>
        /// 日志恢复策略管理
        /// </summary>
        private RecoveryStrategyManager rsmanager;

        public LogMenager()
        {
            content = FrameworkConfig.IocConfig.Resolve<UserLogService>();
            rsmanager = new RecoveryStrategyManager();
        }

        /// <summary>
        /// 日志编写器
        /// </summary>
        /// <returns></returns>
        public void Writer(Permission.Model.UserLog userlog)
        {
            content.AddSave(userlog);            
        }

        /// <summary>
        /// 日志编写器
        /// </summary>
        /// <returns></returns>
        public void Writer(List<Permission.Model.UserLog> loglist)
        {
            var task = content.BulkAdd(loglist);
            task.Start();
            content.SaveChanges();
        }

        /// <summary>
        /// 日志读取器
        /// </summary>
        /// <returns></returns>
        public List<Permission.Model.UserLog> Reader()
        {
            List<Permission.Model.UserLog> list = content.Find().ToList();
            return list;
        }

        /// <summary>
        /// 日志恢复器
        /// </summary>
        /// <returns></returns>
        public bool Restorer(Permission.Model.UserLog userlog)
        {
            return rsmanager.Performer(userlog);            
        }

        
    }
}
