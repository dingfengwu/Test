// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Features.Authentication;

namespace Kehu1688.Framework.Permission.Service
{
    internal class OAuthBearerAuthenticationHandler : AuthenticationHandler<OAuthBearerAuthenticationOptions>
    {
        private readonly string _challenge;

        public OAuthBearerAuthenticationHandler(string challenge)
        {
            _challenge = challenge;
        }

        #pragma warning disable 1998
        public override async Task<bool> HandleRequestAsync()
        {
            return false;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                string requestToken = null;
                string authorization = Request.Headers["Authorization"];
                if (!string.IsNullOrEmpty(authorization))
                {
                    if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        requestToken = authorization.Substring("Bearer ".Length).Trim();
                    }
                }

                // Give application opportunity to find from a different location, adjust, or reject token
                var requestTokenContext = new OAuthRequestTokenContext(Context, requestToken);
                await Options.Provider.RequestToken(requestTokenContext);

                // If no token found, no further work possible
                if (string.IsNullOrEmpty(requestTokenContext.Token))
                {
                    Logger.LogWarning("access token is empty");
                    return AuthenticateResult.Failed(new Exception("access token is empty"));
                }

                // Call provider to process the token into data
                var tokenReceiveContext = new AuthenticationTokenReceiveContext(
                    Context,
                    Options.AccessTokenFormat,
                    requestTokenContext.Token);

                await Options.AccessTokenProvider.ReceiveAsync(tokenReceiveContext);
                if (tokenReceiveContext.Ticket == null)
                {
                    tokenReceiveContext.DeserializeTicket(tokenReceiveContext.Token);
                }

                AuthenticationTicket ticket = tokenReceiveContext.Ticket;
                if (ticket == null)
                {
                    Logger.LogWarning("invalid bearer token received");
                    return AuthenticateResult.Failed(new Exception("invalid bearer token received"));
                }

                // Validate expiration time if present
                DateTimeOffset currentUtc = Options.SystemClock.UtcNow;

                if (ticket.Properties.ExpiresUtc.HasValue &&
                    ticket.Properties.ExpiresUtc.Value < currentUtc)
                {
                    Logger.LogWarning("expired bearer token received");
                    return AuthenticateResult.Failed(new Exception("expired bearer token received"));
                }

                // Give application final opportunity to override results
                var context = new OAuthValidateIdentityContext(Context, Options, ticket);
                if (ticket != null &&
                    ticket.Principal != null &&
                    ticket.Principal.Identity.IsAuthenticated)
                {
                    // bearer token with identity starts validated
                    context.Validated();
                }
                if (Options.Provider != null)
                {
                    await Options.Provider.ValidateIdentity(context);
                }
                if (!context.IsValidated)
                {
                    return AuthenticateResult.Failed(context.Error);
                }

                // resulting identity values go back to caller
                return AuthenticateResult.Success(context.Ticket);
            }
            catch (Exception ex)
            {
                Logger.LogError("Authentication failed", ex);
                return AuthenticateResult.Failed(ex.Message); ;
            }
        }


    }
}
