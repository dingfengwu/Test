﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// Specifies the HTTP response header for the bearer authentication scheme.
    /// </summary>
    public class OAuthChallengeContext : BaseContext
    {
        /// <summary>
        /// Initializes a new <see cref="OAuthRequestTokenContext"/>
        /// </summary>
        /// <param name="context">OWIN environment</param>
        /// <param name="challenge">The www-authenticate header value.</param>
        public OAuthChallengeContext(
            HttpContext context,
            string challenge)
            : base(context)
        {
            Challenge = challenge;
        }

        /// <summary>
        /// The www-authenticate header value.
        /// </summary>
        public string Challenge { get; protected set; }
    }
}
