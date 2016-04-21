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



using Newtonsoft.Json;
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


        /// <summary>
        /// 求指定字符串的sha256
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSHA256(this string str,string saltValue)
        {
#if DNX451 || NET451

            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();
            string source = str;
            if (!string.IsNullOrWhiteSpace(saltValue))
            {
                source += saltValue;
            }
            tmpByte = sha256.ComputeHash(GetByteArray(source));
            sha256.Clear();

            return GetStringValue(tmpByte);
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");            
#endif
        }

        /// <summary>
        /// 获取byte流
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static byte[] GetByteArray(string strKey)
        {

            ASCIIEncoding Asc = new ASCIIEncoding();

            int tmpStrLen = strKey.Length;
            byte[] tmpByte = new byte[tmpStrLen - 1];

            tmpByte = Asc.GetBytes(strKey);

            return tmpByte;

        }

        /// <summary>
        /// 架构byte流转换为字符串
        /// </summary>
        /// <param name="Byte"></param>
        /// <returns></returns>
        public static string GetStringValue(byte[] Byte)
        {
            string tmpString = string.Empty;
            int iCounter;
            for (iCounter = 0; iCounter < Byte.Length; iCounter++)
            {
                tmpString = tmpString + Byte[iCounter].ToString();
            }
            return tmpString;
        }

        /// <summary>
        /// 将json转化为对象
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static object ToJson(this string Json)
        {
            return JsonConvert.DeserializeObject(Json);
        }

        /// <summary>
        /// 将json转化为指定对象
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static T ToJson<T>(string Json)
        {
            return JsonConvert.DeserializeObject<T>(Json);
        }

        /// <summary>
        /// 将对象转化为json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
