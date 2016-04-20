/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IRightOption.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-14 11:16:56
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 权限处理器的选项接口
    /// </summary>
    public interface IRightOption
    {
        /// <summary>
        /// 用来标识此处理器可用于的模块,如果为模块可以为modulekey
        /// 多个用逗号(,)分隔
        /// </summary>
        string Scheme { get; set; }

        /// <summary>
        /// 执行顺序
        /// </summary>
        int Order { get; set; }
    }
}
