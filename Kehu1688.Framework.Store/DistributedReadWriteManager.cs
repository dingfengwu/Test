/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DistributedReadWriteManager.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-18 17:32:13
//----------------------------------------------------------------*/



using Kehu1688.Framework.Config;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    /// <summary>
    /// redis配置信息加载
    /// </summary>
    internal class DistributedReadWriteManager
    {
        /// <summary>
        /// 配置信息实体
        /// </summary>
        public static IList<DbConnectionOption> Instance
        {
            get
            {
                return GetSection();
            }
        }

        private static IList<DbConnectionOption> GetSection()
        {
            List<DbConnectionOption> slaves = new List<DbConnectionOption>();
            var config = FrameworkConfig.IocConfig.Resolve<IConfigurationRoot>();
            config.GetSection("Data:ReadOnlyDbList").Bind(slaves);

            return slaves;
        }
    }
}
