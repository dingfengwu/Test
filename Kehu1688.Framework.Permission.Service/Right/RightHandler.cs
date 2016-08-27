/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightHandler.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-13 17:33:49
//----------------------------------------------------------------*/



using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using Kehu1688.Framework.Config;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 抽像权限处理器
    /// </summary>
    /// <typeparam name="TOption"></typeparam>
    public abstract class RightHandler<TOption> : IRightHandler<TOption>
        where TOption:IRightOption
    {
        public RightHandler(TOption option)
        {
            Option = option;
        }
        
        public TOption Option { get; set; }

        public abstract Task<RightAuthorizeResult> Authorize(RightAuthorizeContext context);

        public virtual Task AuthorizeSuccess(RightAuthorizeContext context) => Task.FromResult<object>(null);

        public virtual Task AuthorizeFail(RightAuthorizeContext context, Exception ex)
        {
            context.HttpContext.Response.StatusCode = 401;

            return Task.FromResult<object>(null);
        }

        public async Task<RightAuthorizeResult> AuthorizeAsync(RightAuthorizeContext context)
        {
            var loggerFactory = context.HttpContext.ApplicationServices.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(nameof(RightHandler<TOption>.AuthorizeAsync));

            var result = RightAuthorizeResult.Skip();
            if (Option.Scheme == RightOption.AUTOMIC_SCHEME || Option.Scheme.Split(',').Contains(context.ModuleKey))
            {
                result = await Authorize(context);
                if (result.Successed)
                {
                    logger.LogVerbose($"scheme is {context.ModuleKey} Right Authorization Success");
                    await AuthorizeSuccess(context);
                }
                else if (result.Failed != null)
                {
                    logger.LogVerbose($"scheme is {context.ModuleKey} Right Authorization Failed");
                    await AuthorizeFail(context, result.Failed);
                }
                else
                {
                    logger.LogVerbose($"scheme is {context.ModuleKey} Right Authorization Skip");
                }
            }
            return result;
        }
    }
}
