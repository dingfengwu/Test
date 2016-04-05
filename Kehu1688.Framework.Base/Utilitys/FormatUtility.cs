/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：FormatUtility.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-28 15:08:07
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base
{
    public static class CommonExtenstion
    {
        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(this string str)
        {
            long number = 0;
            return long.TryParse(str, out number);
        }

        /// <summary>
        /// 获取指定时间的时间戳
        /// </summary>
        /// <param name="utcDate"></param>
        /// <returns></returns>
        public static long Timestamp(this DateTime utcDate)
        {
            var zero = new DateTime(1970, 01, 01, 00, 00, 00,000, DateTimeKind.Utc);
            return (long)(utcDate - zero).TotalSeconds;
        }

        /// <summary>
        /// 求指定字符串的md5值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="saltValue"></param>
        /// <returns></returns>
        public static string GetMD5(this string str,string saltValue)
        {
            string source = str;
            if (!string.IsNullOrWhiteSpace(saltValue))
            {
                source += saltValue;
            }
            var bytes = Encoding.UTF8.GetBytes(source);
            MD5 md5 = MD5.Create();
            bytes = md5.ComputeHash(bytes);

            return BitConverter.ToString(bytes).Replace("-","");
        }
    }
}
