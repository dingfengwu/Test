/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OAuthAuthenticationOptions.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-03-16 16:42:49
//----------------------------------------------------------------*/



using Microsoft.AspNet.Authentication;

namespace Kehu1688.Framework.Permission.Service
{
    public class OAuthAuthenticationOptions: AuthenticationOptions
    {
        private string _authenticationType;

        /// <summary>
        /// The AuthenticationType in the options corresponds to the IIdentity AuthenticationType property. A different
        /// value may be assigned in order to use the same authentication middleware type more than once in a pipeline.
        /// </summary>
        public string AuthenticationType
        {
            get { return _authenticationType; }
            set
            {
                _authenticationType = value;
                Description.AuthenticationScheme = value;
            }
        }

        /// <summary>
        /// If Active the authentication middleware alter the request user coming in and
        /// alter 401 Unauthorized responses going out. If Passive the authentication middleware will only provide
        /// identity and alter responses when explicitly indicated by the AuthenticationType.
        /// </summary>
        public AuthenticationMode AuthenticationMode { get; set; }
    }
}
