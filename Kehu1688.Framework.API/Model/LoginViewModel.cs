/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：LoginViewModel.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-14 11:49:45
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.API
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
