/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DefaultAuthorizationFilter.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-09 9:03:47
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Kehu1688.Framework.Permission.Service;
using Kehu1688.Framework.Config;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc.Filters;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Kehu1688.Framework.API
{
    public class PermissionAuthorizeFilter<TRequirement>:AuthorizeFilter 
        where TRequirement: IAuthorizationRequirement,new()
    {
        private static PermissionAuthorizeFilter<TRequirement> _permissionFilter;
        private static object _lock = new object();

        public PermissionAuthorizeFilter(AuthorizationPolicy policy) : base(policy)
        {

        }

        /// <summary>
        /// 执行权限验证，如果Action上存在AllowAnonymous的Attribute,则不进行验证，
        /// 存在Bearer的AuthorizeFilter,则只进行权限验证，
        /// 如果二者都不存在，则进行OAuth的验证
        /// </summary>
        /// <param name="context">验证请求上下文</param>
        /// <returns></returns>
        public override async Task OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext context)
        {
            if (!context.Filters.Any(item => item is IAllowAnonymous))
            {
                if (!context.Filters.Any(item => item is AuthorizeFilter
                &&(item as AuthorizeFilter).Policy.AuthenticationSchemes.Contains("Bearer")
                && item.GetType() != GetType()))
                {
                    await base.OnAuthorizationAsync(context);
                }
                else
                {
                    var result = await FrameworkConfig.IocConfig.Resolve<PermissionService>().Authorize(context);
                    if (!result)
                    {
                        ErrorApiResult content = new ErrorApiResult();
                        content.Result = false;
                        content.ErrorMsg = Resource.ResourceManager.GetString("ERROR_NOT_PERMISSION");
                        content.ErrorCode = InnerErrorCode.NOT_PERMISSION;

                        await content.ExecuteResultAsync(context);
                    }
                }
            }
        }

        /// <summary>
        /// 默认授权Filter
        /// </summary>
        public static PermissionAuthorizeFilter<TRequirement> Default
        {
            get
            {
                lock(_lock)
                {
                    if (_permissionFilter == null)
                    {
                        AuthorizationPolicyBuilder builder = new AuthorizationPolicyBuilder();
                        builder.AddRequirements(new TRequirement());
                        builder.AddAuthenticationSchemes("Bearer");
                        AuthorizationPolicy policy = builder.Build();
                        _permissionFilter = new PermissionAuthorizeFilter<TRequirement>(policy);
                    }
                }
                return _permissionFilter;
            }
        }
    }
}
