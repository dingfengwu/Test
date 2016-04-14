/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightAuthentication.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-13 17:30:29
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 权限验证类
    /// </summary>
    public class RightAuthorize
    {
        public void RegisterHandler(RightHandler<IRightOption> handler)
        {
            Handlers.Add(handler);
        }

        public List<RightHandler<IRightOption>> Handlers { get; set; }

        public async Task AuthorizeAsync(RightAuthorizeContext context)
        {
            if (string.IsNullOrWhiteSpace(context.ModuleKey))
                throw new ArgumentNullException(nameof(context.ModuleKey));

            if (string.IsNullOrWhiteSpace(context.Operate))
                throw new ArgumentNullException(nameof(context.Operate));


            RightAuthorizeResult result = null;
            foreach (var handler in Handlers.OrderBy(p=>p.Option.Order))
            {
                result = await handler.AuthorizeAsync(context);
                if (!result.Successed)
                {
                    if (!result.RequestCompleted)
                       await HandleAuthorizeFail(context, result.Failed);
                    break;
                }
            }
        }

        /// <summary>
        /// 执行默认的权限验证失败处理
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="result">权限验证结果</param>
        private async Task HandleAuthorizeFail(ActionContext context,
            Exception result)
        {
            var apiResult = new ErrorApiResult();
            apiResult.Result = false;
            apiResult.ErrorMsg = result.Message;
            apiResult.ErrorCode = InnerErrorCode.RIGHT_AUTHORIZE_FAIL;

            await apiResult.ExecuteResultAsync(context); 
        }
    }
}
