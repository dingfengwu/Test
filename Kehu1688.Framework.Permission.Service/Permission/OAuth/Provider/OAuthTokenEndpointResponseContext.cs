// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// Provides context information used at the end of a token-endpoint-request.
    /// </summary>
    public class OAuthTokenEndpointResponseContext : EndpointContext<OAuthAuthorizationServerOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthTokenEndpointResponseContext"/> class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="ticket"></param>
        /// <param name="tokenEndpointRequest"></param>
        public OAuthTokenEndpointResponseContext(
            HttpContext context,
            OAuthAuthorizationServerOptions options,
            AuthenticationTicket ticket,
            TokenEndpointRequest tokenEndpointRequest,
            string accessToken,
            IDictionary<string, object> additionalResponseParameters)
            : base(context, options)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            Identity = ticket.Principal;
            Properties = ticket.Properties;
            TokenEndpointRequest = tokenEndpointRequest;
            AdditionalResponseParameters = new Dictionary<string, object>(StringComparer.Ordinal);
            TokenIssued = Identity != null;
            AccessToken = accessToken;
            AdditionalResponseParameters = additionalResponseParameters;
        }

        /// <summary>
        /// Gets the identity of the resource owner.
        /// </summary>
        public ClaimsPrincipal Identity { get; private set; }

        /// <summary>
        /// Dictionary containing the state of the authentication session.
        /// </summary>
        public AuthenticationProperties Properties { get; private set; }

        /// <summary>
        /// The issued Access-Token
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets information about the token endpoint request. 
        /// </summary>
        public TokenEndpointRequest TokenEndpointRequest { get; set; }

        /// <summary>
        /// Gets whether or not the token should be issued.
        /// </summary>
        public bool TokenIssued { get; private set; }

        /// <summary>
        /// Enables additional values to be appended to the token response.
        /// </summary>
        public IDictionary<string, object> AdditionalResponseParameters { get; private set; }

        /// <summary>
        /// Issues the token.
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="properties"></param>
        public void Issue(ClaimsPrincipal identity, AuthenticationProperties properties)
        {
            Identity = identity;
            Properties = properties;
            TokenIssued = true;
        }
    }
}
