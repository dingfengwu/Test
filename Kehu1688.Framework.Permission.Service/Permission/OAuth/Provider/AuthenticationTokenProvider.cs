/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：AuthenticationTokenProvider.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-15
//----------------------------------------------------------------*/



using System;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class AuthenticationTokenProvider: IAuthenticationTokenProvider
    {
        public Action<AuthenticationTokenCreateContext> OnCreate { get; set; }
        public Func<AuthenticationTokenCreateContext, Task> OnCreateAsync { get; set; }
        public Action<AuthenticationTokenReceiveContext> OnReceive { get; set; }
        public Func<AuthenticationTokenReceiveContext, Task> OnReceiveAsync { get; set; }

        public virtual void Create(AuthenticationTokenCreateContext context)
        {
            if (OnCreateAsync != null && OnCreate == null)
            {
                throw new InvalidOperationException(Resources.Exception_AuthenticationTokenDoesNotProvideSyncMethods);
            }
            if (OnCreate != null)
            {
                OnCreate.Invoke(context);
            }
        }

        public virtual async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            if (OnCreateAsync != null && OnCreate == null)
            {
                throw new InvalidOperationException(Resources.Exception_AuthenticationTokenDoesNotProvideSyncMethods);
            }
            if (OnCreateAsync != null)
            {
                await OnCreateAsync.Invoke(context);
            }
            else
            {
                Create(context);
            }
        }

        public virtual void Receive(AuthenticationTokenReceiveContext context)
        {
            if (OnReceiveAsync != null && OnReceive == null)
            {
                throw new InvalidOperationException(Resources.Exception_AuthenticationTokenDoesNotProvideSyncMethods);
            }

            if (OnReceive != null)
            {
                OnReceive.Invoke(context);
            }
        }

        public virtual async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            if (OnReceiveAsync != null && OnReceive == null)
            {
                throw new InvalidOperationException(Resources.Exception_AuthenticationTokenDoesNotProvideSyncMethods);
            }
            if (OnReceiveAsync != null)
            {
                await OnReceiveAsync.Invoke(context);
            }
            else
            {
                Receive(context);
            }
        }
    }
}
