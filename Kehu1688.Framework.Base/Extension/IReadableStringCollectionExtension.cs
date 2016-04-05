/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IReadableStringCollectionExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-16 16:00:48
//----------------------------------------------------------------*/



using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base
{
    public static class IReadableStringCollectionExtension
    {
        public static string Get(this IReadableStringCollection str, string key)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            if (str.Keys.Contains(key))
                return str[key];

            return null;
        }
    }
}
