// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.Http;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// Base class used for certain event contexts
    /// </summary>
    public abstract class BaseValidatingClientContext : BaseValidatingContext<OAuthAuthorizationServerOptions>
    {
        /// <summary>
        /// Initializes base class used for certain event contexts
        /// </summary>
        protected BaseValidatingClientContext(
            HttpContext context,
            OAuthAuthorizationServerOptions options,
            string clientId)
            : base(context, options)
        {
            ClientId = clientId;
        }

        /// <summary>
        /// The "client_id" parameter for the current request. The Authorization Server application is responsible for 
        /// validating this value identifies a registered client.
        /// </summary>
        public string ClientId { get; protected set; }
    }
}
