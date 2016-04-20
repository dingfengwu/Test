/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OperateRightHandler.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-14 17:53:36
//----------------------------------------------------------------*/



using System;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class OperateRightHandler : RightHandler<RightOption>
    {
        public OperateRightHandler(RightOption options) : base(options) { }

        public override Task<RightAuthorizeResult> Authorize(RightAuthorizeContext context)
        {
            return Task.FromResult(RightAuthorizeResult.Fail(new NotImplementedException("no impletement")));
        }
    }
}
