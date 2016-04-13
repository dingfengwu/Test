/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：PermissionDomainService.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-11 21:19:19
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Kehu1688.Framework.Store;
using Microsoft.AspNet.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 授权管理
    /// </summary>
    public class PermissionService:IDomainService
    {
        EntityFrameworkRepository _rep;
        DepartmentService _dptService;

        public PermissionService(EntityFrameworkRepository rep, 
            DepartmentService departmentService)
        {
            _rep = rep;
            _dptService = departmentService;
        }

        #pragma warning disable 1998
        public virtual async Task<bool> Authorize(AuthorizationContext context)
        {
            var action = context.ActionDescriptor.AttributeRouteInfo;
            var permissionAuthorize = context.Filters.OfType<PermissionAuthroizeAttribute>().FirstOrDefault();
            if (permissionAuthorize != null)
            {
                var operate = permissionAuthorize.Operate;
                var resource = permissionAuthorize.Module;

                
            }

            return true;
        }
    }
}
