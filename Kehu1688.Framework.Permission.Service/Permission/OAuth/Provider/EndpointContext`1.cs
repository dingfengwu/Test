﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// Base class used for certain event contexts
    /// </summary>
    public abstract class EndpointContext<TOptions> : BaseContext<TOptions>
    {
        /// <summary>
        /// Creates an instance of this context
        /// </summary>
        protected EndpointContext(HttpContext context, TOptions options)
            : base(context,options)
        {
            
        }
        
        /// <summary>
        /// True if the request should not be processed further by other components.
        /// </summary>
        public bool IsRequestCompleted { get; private set; }

        /// <summary>
        /// Prevents the request from being processed further by other components. 
        /// IsRequestCompleted becomes true after calling.
        /// </summary>
        public void RequestCompleted()
        {
            IsRequestCompleted = true;
        }
    }
}
