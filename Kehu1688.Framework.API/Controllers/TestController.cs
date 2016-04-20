/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：TestController.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-16 9:39:15
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Kehu1688.Framework.Permission.Service;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kehu1688.Framework.API.Controllers
{
    [Route("[controller]")]
    public class TestController: ApiController
    {
#pragma warning disable 1998
        [HttpPost("Test")]
        [PermissionAuthroize(Module = "Customer", Operate = "Edit")]
        public async Task<ApiResult> Test()
        {
            return this.Good();
        }

        [HttpGet("LongTest")]
        [AllowAnonymous]
        public async Task<string> LongTest()
        {
            Context.Session.Set("Id", Encoding.UTF8.GetBytes("1"));
            await Task.Run(() => { Thread.Sleep(30 * 1000); });
            return Context.TraceIdentifier;
            //return Thread.CurrentThread.ManagedThreadId;
        }

        [HttpGet("ShortTest")]
        [AllowAnonymous]
        public async Task<string> ShortTest()
        {
            Context.Session.Set("Id1", Encoding.UTF8.GetBytes("1"));
            await Task.Run(() =>
            {
                Thread.Sleep(10 * 1000);
            });
            return Context.TraceIdentifier;
            //return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
