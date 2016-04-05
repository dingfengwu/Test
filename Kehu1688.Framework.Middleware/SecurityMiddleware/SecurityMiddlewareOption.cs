/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：SecurityMiddlewareOption.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-26 11:35:40
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Middleware
{
    public class SecurityMiddlewareOption
    {
        /// <summary>
        /// 允许参数加密,需要客户端配合
        /// </summary>
        public bool AllowArgumentEncrypt { get; set; }

        /// <summary>
        /// 主要用于加盐算法时的盐值,且做为每个软件的唯一标识
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 验证数据完整性
        /// </summary>
        public bool ValidateData { get; set; }
    }
}
