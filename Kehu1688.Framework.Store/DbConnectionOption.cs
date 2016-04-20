/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DbConnectionOption.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-18 17:35:11
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    public class DbConnectionOption
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public string Password { get; set; }
    }
}
