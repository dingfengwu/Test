using Kehu1688.Framework.Base;
using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Permission.Service;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.OptionsModel;
using Microsoft.Extensions.Configuration;

namespace Kehu1688.Framework.Permission.Service
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException(nameof(publicClientId));
            }

            _publicClientId = publicClientId;
        }

        /// <summary>
        /// 验证码方式授权的验证,授权类型authorization_code
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
        {
            //context.Ticket.Principal.Claims[]

            context.Validated();
            
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 资源归属人请求时的验证,授权类型password
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userService = context.HttpContext.ApplicationServices.GetService<UserService>();
            var roleService = context.HttpContext.ApplicationServices.GetService<RoleService>();
            var optionsMgr = context.HttpContext.ApplicationServices.GetService<IOptions<IdentityOptions>>();
            
            User user = await userService.FindByNameAsync(context.UserName);
            if (user == null)
            {
                context.SetError("invalid_grant", Resources.Error_NotFounUserName);
                return;
            }
            if (!await userService.CheckPasswordAsync(user, context.Password))
            {
                context.SetError("invalid_grant", Resources.Error_NotFounPassword);
                return;
            }
            
            UserClaimsPrincipalFactory<User, Role> claimsFactory
                = new UserClaimsPrincipalFactory<User, Role>(userService, roleService, optionsMgr);
            var principal = await claimsFactory.CreateAsync(user);
            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, properties, OAuthDefaults.AuthenticationType);
            context.Validated(ticket);
        }
        private AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }

        /// <summary>
        /// 客户端授权时的验证,授权类型为client_credentials
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var userService = context.HttpContext.ApplicationServices.GetService<UserService>();
            var roleService = context.HttpContext.ApplicationServices.GetService<RoleService>();
            var optionsMgr = context.HttpContext.ApplicationServices.GetService<IOptions<IdentityOptions>>();

            User user = await userService.FindByUserToken(context.ClientId);
            if (user == null)
            {
                context.SetError("invalid_grant", Resources.Error_NotFounUserName);
                return;
            }

            UserClaimsPrincipalFactory<User, Role> claimsFactory
                = new UserClaimsPrincipalFactory<User, Role>(userService, roleService, optionsMgr);
            var principal = await claimsFactory.CreateAsync(user);
            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, properties, OAuthDefaults.AuthenticationType);
            context.Validated(ticket);
        }

        /// <summary>
        /// 获取刷新token时的验证，授权类型为refresh_token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            //此处需要验证是否为失效的refreshToken,因为执行refresh_token时，前一次的refreshToken应该失效.
            //to do:
            return base.GrantRefreshToken(context);
        }

        /// <summary>
        /// 自定义授权时的验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            return base.GrantCustomExtension(context);
        }
        
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Items)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 验证client_id与client_secret
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
                context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                //需实现验证client_id与client_secret
                //to do:

                context.Validated(clientId);
            }
            else
            {
                context.Validated();
            }
            return Task.FromResult(0);
        }

        /// <summary>
        /// 验证redirect_uri
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            //验证跳转地址
            //to do:
            context.Validated();

            return Task.FromResult<object>(null);
        }
        
        



        public override Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            //处理不是很好
            //to do:

            var config = context.HttpContext.ApplicationServices.GetService<IConfigurationRoot>();
            var inner = context.Request.Query["inner"];
            if (inner != "1")
            {
                var queryParams = context.Request.QueryString.Value;
                var url = $"{config["Host"]}/ApiAuthorize{queryParams}";
                context.Response.Redirect(url);
            }

            context.RequestCompleted();
            return Task.FromResult<object>(null);
        }
    }
}