// Copyright (c) Microsoft Corporation, Inc. All rights reserved.
// Licensed under the MIT License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    ///     Extensions off of IApplicationBuilder to make it easier to configure the SignInCookies
    /// </summary>
    public static class AppBuilderExtensions
    {
        private const string DEFAULT_REFRESH_TOKEN_PURPOSE = "REFRESH_TOKEN";
        private const string DEFAULT_AUTHORIZATION_CODE_PURPOSE = "AUTHORIZATION_CODE";
        private const string DEFAULT_ACCESS_TOKEN_PURPOSE = "ACCESS_TOKEN";

        /// <summary>
        ///     Configure the app to use owin middleware based oauth bearer tokens
        /// </summary>
        /// <param name="this"></param>
        /// <param name="options"></param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Auth",
            Justification = "By Design")]
        public static void UseOAuthBearerTokens(this IApplicationBuilder @this, OAuthAuthorizationServerOptions options)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            @this.UseOAuthAuthorizationServer(options);
            @this.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat = options.AccessTokenFormat,
                AccessTokenProvider = options.AccessTokenProvider,
                AuthenticationMode = options.AuthenticationMode,
                AuthenticationType = options.AuthenticationType,
                Description = options.Description,
                Provider = new ApplicationOAuthBearerProvider(),
                SystemClock = options.SystemClock,

                AutomaticAuthenticate = false,
                AuthenticationScheme = "Bearer"
            });

            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            //{
            //    AccessTokenFormat = options.AccessTokenFormat,
            //    AccessTokenProvider = options.AccessTokenProvider,
            //    AuthenticationMode = AuthenticationMode.Passive,
            //    AuthenticationType = OAuthDefaults.ExternalAuthenticationType,
            //    Description = options.Description,
            //    Provider = new ExternalOAuthBearerProvider(),
            //    SystemClock = options.SystemClock
            //});
        }

        /// <summary>
        /// 使用Bearer验证Token
        /// </summary>
        /// <param name="@this">IApplicationBuilder</param>
        /// <param name="config">OAuthAuthorizationServerOptions配置</param>
        public static void UseOAuthBearerTokens(this IApplicationBuilder @this, Action<OAuthAuthorizationServerOptions> config)
        {
            var options = new OAuthAuthorizationServerOptions();
            if (config != null)
            {
                config(options);
            }
            @this.UseOAuthBearerTokens(options);
        }
        private class ApplicationOAuthBearerProvider : OAuthBearerAuthenticationProvider
        {
            public override Task ValidateIdentity(OAuthValidateIdentityContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                if (context.Ticket.Principal.Claims.Any(c => c.Issuer != ClaimsIdentity.DefaultIssuer))
                {
                    context.Rejected();
                }
                return Task.FromResult<object>(null);
            }
        }

        private class ExternalOAuthBearerProvider : OAuthBearerAuthenticationProvider
        {
            public override Task ValidateIdentity(OAuthValidateIdentityContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                if (context.Ticket.Principal.Claims.Count() == 0)
                {
                    context.Rejected();
                }
                else if (context.Ticket.Principal.Claims.All(c => c.Issuer == ClaimsIdentity.DefaultIssuer))
                {
                    context.Rejected();
                }

                return Task.FromResult<object>(null);
            }
        }

        /// <summary>
        /// 创建默认RefreshToken实例
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static AuthenticationTokenProvider CreateRefreshTokenProvider(this IApplicationBuilder app)
        {
            return CreateProvider(DEFAULT_REFRESH_TOKEN_PURPOSE);
        }


        /// <summary>
        /// 创建默认AuthorizationCode实例
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static AuthenticationTokenProvider CreateAuthorizationCodeProvider(this IApplicationBuilder app)
        {
            return CreateProvider(DEFAULT_AUTHORIZATION_CODE_PURPOSE);
        }

        /// <summary>
        /// 创建默认AccessToken实例
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static AuthenticationTokenProvider CreateAccessTokenProvider(this IApplicationBuilder app)
        {
            return CreateProvider(DEFAULT_ACCESS_TOKEN_PURPOSE);
        }

        private static AuthenticationTokenProvider CreateProvider(string purpose)
        {
            var provider = new AuthenticationTokenProvider();
            provider.OnCreateAsync = (context) =>
            {
                context.SetToken(context.SerializeTicket(purpose));
                return Task.FromResult<object>(null);
            };

            provider.OnReceiveAsync = (context) =>
            {
                context.DeserializeTicket(context.Token, purpose);
                return Task.FromResult<object>(null);
            };

            provider.OnCreate = (context) =>
            {
                context.SetToken(context.SerializeTicket(purpose));
            };

            provider.OnReceive = (context) =>
            {
                context.DeserializeTicket(context.Token, purpose);
            };

            return provider;
        }
    }
}