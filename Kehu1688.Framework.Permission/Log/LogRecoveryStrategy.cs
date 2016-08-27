/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：LogRecoveryStrategy.cs
// 文件功能描述：
// 日志恢复策略实体类
//
// 创建人  ：WZJ
// 创建日期：2016-04-36 10:40:00
//----------------------------------------------------------------*/


using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Model
{
    public class LogRecoveryStrategy : IEntity<LogRecoveryStrategy>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public string method { get; set; }

        /// <summary>
        /// 调用入口
        /// </summary>
        public string callPortal { get; set; }

        /// <summary>
        /// 参数格式
        /// </summary>
        public string parameterFormat { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int state { set; get; }
    }
}
