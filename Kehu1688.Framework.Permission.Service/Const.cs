/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Const.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-20 17:33:19
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class Const
    {
        /// <summary>
        /// 验证类型
        /// </summary>
        public const string AUTHORIZE_TYPE = "Microsoft.AspNet.Identity.Application";

        /// <summary>
        /// 验证IDENTITY的SCHEME
        /// </summary>
        public const string AUTHORIZE_NAME_IDENTITY_SCHEME = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

        /// <summary>
        /// 验证NAME的SCHEME
        /// </summary>
        public const string AUTHORIZE_NAME_SCHEME = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
    }
}
