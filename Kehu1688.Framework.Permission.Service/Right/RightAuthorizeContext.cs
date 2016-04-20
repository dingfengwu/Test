/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RightAuthorizeContext.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-14 11:57:09
//----------------------------------------------------------------*/



using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    /// <summary>
    /// 权限验证上下文
    /// </summary>
    public class RightAuthorizeContext:ActionContext
    {
        public RightAuthorizeContext(ActionContext context, string moduleKey, string operate, IList<ParameterDescriptor> parameters):base(context)
        {
            ModuleKey = moduleKey;
            Operate = operate;
            Parameters = parameters;
        }
        
        /// <summary>
        /// 模块Key
        /// </summary>
        public string ModuleKey { get; private set; }

        /// <summary>
        /// 操作key
        /// </summary>
        public string Operate { get; private set; }

        /// <summary>
        /// 模块所对应实体的Id
        /// </summary>
        public IList<ParameterDescriptor> Parameters { get; private set; }
    }
}
