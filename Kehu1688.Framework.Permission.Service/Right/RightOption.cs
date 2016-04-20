/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightOption.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-14 17:50:55
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class RightOption : IRightOption
    {
        /// <summary>
        /// 执行顺序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 用来标识此处理器可用于的模块,如果为模块可以为modulekey
        /// 多个用逗号(,)分隔
        /// </summary>
        public string Scheme { get; set; } = AUTOMIC_SCHEME;

        /// <summary>
        /// 自动处理
        /// </summary>
        public const string AUTOMIC_SCHEME = "Automic";
    }
}
