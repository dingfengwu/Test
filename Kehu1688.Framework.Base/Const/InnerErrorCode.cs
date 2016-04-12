/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：InnerErrorCode.cs
// 文件功能描述：
// 错误代码
//
// 创建人  ：WDF
// 创建日期：2016-03-23 17:48:34
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base
{
    public sealed class InnerErrorCode
    {
        /// <summary>
        /// 视图模型未验证
        /// </summary>
        public const string MODEL_INVOLID = "1001";

        /// <summary>
        /// 指定模型不能为空
        /// </summary>
        public const string MODEL_NOT_NULL = "1002";

        /// <summary>
        /// 没有授权
        /// </summary>
        public const string NOT_PERMISSION = "1003";

        /// <summary>
        /// 全局异常
        /// </summary>
        public const string GLOBAL_EXCEPTION = "1004";

    }
}
