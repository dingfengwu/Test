// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http;
using System;

namespace Kehu1688.Framework.Permission.Service
{
    public class AuthenticationTokenReceiveContext : BaseContext
    {
        private readonly ISecureDataFormat<AuthenticationTicket> _secureDataFormat;

        public AuthenticationTokenReceiveContext(
            HttpContext context,
            ISecureDataFormat<AuthenticationTicket> secureDataFormat,
            string token) : base(context)
        {
            if (secureDataFormat == null)
            {
                throw new ArgumentNullException("secureDataFormat");
            }
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }
            _secureDataFormat = secureDataFormat;
            Token = token;
        }

        public string Token { get; protected set; }

        public AuthenticationTicket Ticket { get; protected set; }

        public void DeserializeTicket(string protectedData,string purpose=null)
        {
            Ticket = _secureDataFormat.Unprotect(protectedData, purpose);
        }

        public void SetTicket(AuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }
            Ticket = ticket;
        }
    }
}
