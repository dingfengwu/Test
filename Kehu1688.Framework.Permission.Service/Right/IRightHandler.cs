/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IRightHandler.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-13 17:31:14
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 权限处理接口
    /// </summary>
    public interface IRightHandler
    {
        Task<RightAuthorizeResult> Authorize(RightAuthorizeContext context);
    }
}
