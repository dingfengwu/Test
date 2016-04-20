/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IdGenerater.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 19:35:37
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base
{
    /// <summary>
    /// 实体Id生成器
    /// </summary>
    public class IdGenerator
    {
        static object _lock = new object();
        static IdGenerator _instance;
        /// <summary>
        /// 生成唯一Id
        /// </summary>
        /// <returns></returns>
        public long GuidToLongId()
        {
            return BitConverter.ToInt64(Guid.NewGuid().ToByteArray(),0);
        }

        public static IdGenerator Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new IdGenerator();
                    }
                }
                return _instance;
            }
        }
    }
}
