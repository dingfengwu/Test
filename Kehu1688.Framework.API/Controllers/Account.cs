/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：Account.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-14 11:44:22
//----------------------------------------------------------------*/



using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Permission.Service;
using Kehu1688.Framework.Permission.Service.DomainService;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Filters;
using System.Web.Http;
using Kehu1688.Framework.Base;

namespace Kehu1688.Framework.API.Controllers
{
    [Route("[controller]")]
    public class AccountController: ApiController
    {
        private PermissionService _service;
        private UserService _userService;
        private ILogger _logger;
        private SignInManager<User> _signInManager;

        public AccountController(PermissionService service,UserService userService, ILoggerFactory loger, SignInManager<User> signInManager)
        {
            _service = service;
            _userService = userService;
            _logger = loger.CreateLogger(nameof(AccountController));
            _signInManager = signInManager;
            
        }

        [HttpPost]
        [Route("Test")]
        [PermissionAuthroize]
        public async Task<ApiResult> Test()
        {
            return this.Good();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<ApiResult> Register([FromForm] UserViewModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return ErrorApiResult.FromModelState(ModelState);
            }
            else
            {
                var user = new User() { UserName = model.UserName, Email = model.Password };
                IdentityResult result = await _userService.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
            }
            return this.Good();
        }
        private ApiResult GetErrorResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return ErrorApiResult.FromModelState(ModelState);
        }
        
    }
}
