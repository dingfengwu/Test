/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：ErrorAttribute.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-23 16:47:18
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base.Attributes
{
    /// <summary>
    /// 用来标识此控制器所用的错误代码前缀,10为保留前缀，请勿用
    /// </summary>
    public class ErrorCodeAttribute:Attribute
    {
        public ErrorCodeAttribute(string errorCodePrefix)
        {
            ErrorCodePrefix = errorCodePrefix;
        }

        /// <summary>
        /// 错误码前缀
        /// </summary>
        public string ErrorCodePrefix { get; set; }
    }
}
