/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightAuthorizeResult.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-14 15:18:56
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 权限验证结果
    /// </summary>
    public class RightAuthorizeResult
    {
        /// <summary>
        /// 成功
        /// </summary>
        public bool Successed { get; private set; }

        /// <summary>
        /// 失败
        /// </summary>
        public Exception Failed { get; private set; }

        /// <summary>
        /// 跳过
        /// </summary>
        public bool Skiped { get; private set; }

        /// <summary>
        /// 请求是否已经完成
        /// </summary>
        public bool RequestCompleted { get; private set; }


        public static RightAuthorizeResult Success()
        {
            return new RightAuthorizeResult() { Successed = true };
        }

        public static RightAuthorizeResult Fail(Exception failure)
        {
            return new RightAuthorizeResult { Failed=failure };
        }

        public static RightAuthorizeResult Skip()
        {
            return new RightAuthorizeResult { Skiped = true };
        }


    }
}
