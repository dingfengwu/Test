/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：OperateLogService.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 15:30:18
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Service
{
    public class OperateLogService:IDomainService
    {
        /// <summary>
        /// 记录操作
        /// </summary>
        /// <param name="moduleKey">模块key</param>
        /// <param name="operate">操作</param>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        public virtual async Task Log(string moduleKey, string operate, string key)
        {

        }
    }
}
