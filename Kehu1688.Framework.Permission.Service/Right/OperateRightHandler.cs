/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OperateRightHandler.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-14 17:53:36
//----------------------------------------------------------------*/



using Microsoft.AspNet.Http.Features.Authentication;
using System;
using System.Threading.Tasks;
using System.Linq;
using Kehu1688.Framework.Config;
using Microsoft.AspNet.Http;
using System.Net;

namespace Kehu1688.Framework.Permission.Service
{
    public class OperateRightHandler : RightHandler<RightOption>
    {
        public OperateRightHandler(RightOption options) : base(options) { }

        public override async Task<RightAuthorizeResult> Authorize(RightAuthorizeContext context)
        {
            string userId = "", username = "";
            var user = context.HttpContext.User;
            foreach (var identity in user.Identities)
            {
                if (identity.IsAuthenticated && identity.AuthenticationType == Const.AUTHORIZE_TYPE)
                {
                    foreach (var item in identity.Claims)
                    {
                        if (item.Type == Const.AUTHORIZE_NAME_IDENTITY_SCHEME)
                        {
                            userId = item.Value;
                        }
                        else if (item.Type == Const.AUTHORIZE_NAME_SCHEME)
                        {
                            username = item.Value;
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(username))
            {
                throw new InvalidOperationException(Resources.EXCEPTION_USER_NOT_FOUND);
            }

            var userService = FrameworkConfig.IocConfig.Resolve<UserService>();
            var userInfo =await userService.FindUserById(userId);

            throw new Exception();
        }
    }
}
