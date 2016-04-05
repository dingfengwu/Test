/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OK.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-23 19:47:39
//----------------------------------------------------------------*/



using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.API
{
    public class OK : ApiResult { }

    public static class ControlExtension
    {
        public static ApiResult Good(this Controller controler)
        {
            return new OK() { Result = true };
        }
    }
}
