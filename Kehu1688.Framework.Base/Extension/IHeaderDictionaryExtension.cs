/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IHeaderDictionaryExtension.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-16 11:54:55
//----------------------------------------------------------------*/



using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base
{
    public static class IHeaderDictionaryExtension
    {
        public static void Set(this IHeaderDictionary dict, string key, string value)
        {
            if (dict.Keys.Contains(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        public static string Get(this IHeaderDictionary dict, string key)
        {
            if (dict.Keys.Contains(key))
            {
                return dict[key];
            }
            return null;
        }
    }
}
