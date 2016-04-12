/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：GlobalException.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-12 10:38:04
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.AspNet.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.API
{
    public class GlobalException : IExceptionFilter
    {
        public async void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 400;
            ErrorApiResult result = new ErrorApiResult();
            result.ErrorMsg = context.Exception.Message;
            result.ErrorCode = InnerErrorCode.GLOBAL_EXCEPTION;

            await result.ExecuteResultAsync(context);
        }
    }
}
