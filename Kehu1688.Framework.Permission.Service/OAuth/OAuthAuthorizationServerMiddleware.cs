/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OAuthAuthorizationServerMiddleware.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-15 19:11:40
//----------------------------------------------------------------*/



using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;
using System;

namespace Kehu1688.Framework.Permission.Service
{
    public class OAuthAuthorizationServerMiddleware : AuthenticationMiddleware<OAuthAuthorizationServerOptions>
    {
        public OAuthAuthorizationServerMiddleware(
            RequestDelegate next,
            OAuthAuthorizationServerOptions options,
            ILoggerFactory logger,
            IUrlEncoder encoder,
            IDataProtectionProvider dataProtectionProvider
            ) :base(next,options,logger,encoder)
        {
            if (dataProtectionProvider == null)
            {
                throw new ArgumentNullException(nameof(dataProtectionProvider));
            }

            if (Options.Provider == null)
            {
                Options.Provider = new OAuthAuthorizationServerProvider();
            }

            if (Options.AccessTokenFormat == null)
            {
                Options.AccessTokenFormat = new TicketDataFormat(dataProtectionProvider.CreateProtector("Access_Token"));
            }
            if(Options.RefreshTokenFormat==null)
            {
                Options.RefreshTokenFormat = new TicketDataFormat(dataProtectionProvider.CreateProtector("Refresh_Token"));
            }
            if (Options.AuthorizationCodeFormat == null)
            {
                Options.AuthorizationCodeFormat = new TicketDataFormat(dataProtectionProvider.CreateProtector("Auth_Code"));
            }
            if (Options.AuthorizeEndpointPath == null)
            {
                Options.AuthorizeEndpointPath = new PathString("/Authorize");
            }
            if (Options.TokenEndpointPath == null)
            {
                Options.AuthorizeEndpointPath = new PathString("/Token");
            }

            if (Options.AuthorizationCodeProvider == null)
            {
                Options.AuthorizationCodeProvider = new AuthenticationTokenProvider();
            }
            if (Options.AccessTokenProvider == null)
            {
                Options.AccessTokenProvider = new AuthenticationTokenProvider();
            }
            if (Options.RefreshTokenProvider == null)
            {
                Options.RefreshTokenProvider = new AuthenticationTokenProvider();
            }
        }
        protected override AuthenticationHandler<OAuthAuthorizationServerOptions> CreateHandler()
        {
            return new OAuthAuthorizationServerHandler() ;
        }
    }
}
