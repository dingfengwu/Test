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

namespace Kehu1688.Framework.API
{
    public class PermissionAuthorizeFilter<TRequirement>:AuthorizeFilter where TRequirement: IAuthorizationRequirement,new()
    {
        private static PermissionAuthorizeFilter<TRequirement> _permissionFilter;
        private static object _lock = new object();

        public PermissionAuthorizeFilter(AuthorizationPolicy policy) : base(policy)
        {

        }

        /// <summary>
        /// 验证时执行的事件,
        /// 在此方法中只做错误数据的输出，成功则不操作
        /// </summary>
        /// <param name="context">验证请求上下文</param>
        /// <returns></returns>
        public override async Task OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext context)
        {
            //此处不可再调用父类的OnAuthorizationAsync,否则Bearer中间件验证会出现403的错误

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
