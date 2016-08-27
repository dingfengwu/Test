/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DefaultBehavior.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-16
//----------------------------------------------------------------*/



using System;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    internal class DefaultBehavior
    {
        internal static readonly Func<OAuthValidateAuthorizeRequestContext, Task> ValidateAuthorizeRequest = context =>
        {
            context.Validated();
            return Task.FromResult<object>(null);
        };

        internal static readonly Func<OAuthValidateTokenRequestContext, Task> ValidateTokenRequest = context =>
        {
            context.Validated();
            return Task.FromResult<object>(null);
        };

        internal static readonly Func<OAuthGrantAuthorizationCodeContext, Task> GrantAuthorizationCode = context =>
        {
            if (context.Ticket != null && context.Ticket.Principal != null && context.Ticket.Principal.Identity.IsAuthenticated)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        };

        internal static readonly Func<OAuthGrantRefreshTokenContext, Task> GrantRefreshToken = context =>
        {
            if (context.Ticket != null && context.Ticket.Principal != null && context.Ticket.Principal.Identity.IsAuthenticated)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        };
    }
}
