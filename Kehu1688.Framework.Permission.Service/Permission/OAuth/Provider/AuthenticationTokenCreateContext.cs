// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http;
using System;

namespace Kehu1688.Framework.Permission.Service
{
    public class AuthenticationTokenCreateContext : BaseContext
    {
        private readonly ISecureDataFormat<AuthenticationTicket> _secureDataFormat;

        public AuthenticationTokenCreateContext(
            HttpContext context,
            ISecureDataFormat<AuthenticationTicket> secureDataFormat,
            AuthenticationTicket ticket)
            : base(context)
        {
            if (secureDataFormat == null)
            {
                throw new ArgumentNullException("secureDataFormat");
            }
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }
            _secureDataFormat = secureDataFormat;
            Ticket = ticket;
        }

        public string Token { get; protected set; }

        public AuthenticationTicket Ticket { get; protected set; }

        public string SerializeTicket(string purpose=null)
        {
            return _secureDataFormat.Protect(Ticket,purpose);
        }

        public void SetToken(string tokenValue)
        {
            if (tokenValue == null)
            {
                throw new ArgumentNullException("tokenValue");
            }
            Token = tokenValue;
        }
    }
}
