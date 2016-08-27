// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.Http;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// An event raised after the Authorization Server has processed the request, but before it is passed on to the web application.
    /// Calling RequestCompleted will prevent the request from passing on to the web application.
    /// </summary>
    public class OAuthAuthorizeEndpointContext : EndpointContext<OAuthAuthorizationServerOptions>
    {
        /// <summary>
        /// Creates an instance of this context
        /// </summary>
        public OAuthAuthorizeEndpointContext(
            HttpContext context,
            OAuthAuthorizationServerOptions options,
            AuthorizeEndpointRequest authorizeRequest)
            : base(context, options)
        {
            AuthorizeRequest = authorizeRequest;
        }

        /// <summary>
        /// Gets OAuth authorization request data.
        /// </summary>
        public AuthorizeEndpointRequest AuthorizeRequest { get; private set; }
    }
}
