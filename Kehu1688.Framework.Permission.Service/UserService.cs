/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：UserManagerExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-17 10:45:37
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 用户管理 
    /// </summary>
    public class UserService : UserManager<User>, IDomainService
    {
        private ApplicationUserStore _store;
        public UserService(ApplicationUserStore store,
            IOptions<IdentityOptions> optionAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidator,
            IEnumerable<IPasswordValidator<User>> passwordValidator,
            ILookupNormalizer normalizer,
            IdentityErrorDescriber errorDescriber,
            IServiceProvider serviceProvider,
            ILogger<UserService> logger,
            IHttpContextAccessor accessor)
            :base(store, optionAccessor, passwordHasher, 
                 userValidator, passwordValidator,normalizer, 
                 errorDescriber, serviceProvider,logger, accessor)
        {
            Options = optionAccessor?.Value??new IdentityOptions();
            PasswordHasher = passwordHasher;

            _store = store;
        }

        public IPasswordHasher<User> PasswordHasher { get;private set; }

        public IdentityOptions Options { get; private set; }

        private static TService GetService<TService>(HttpContext context) where TService:class
        {
            if(context==null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.ApplicationServices.GetService<TService>();
        }

        /// <summary>
        /// 查找用户通过UserToken
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        /// <example>
        /// 
        /// </example>
        internal Task<User> FindByUserToken(string clientId)
        {
            if(string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            
            var user = _store.Users.Where(p => p.UserToken == clientId).FirstOrDefault();
            return Task.FromResult(user);
        }
    }
}
