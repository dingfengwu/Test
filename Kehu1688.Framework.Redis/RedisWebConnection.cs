/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RedisWebConnection.cs
// 文件功能描述：
// 自制的 Redis 缓存服务器Web API 模块连接和调用
//
// 创建人  ：WZJ
// 创建日期：2016-04-12 14:13:00
//----------------------------------------------------------------*/


using Kehu1688.Framework.Base.Cache;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Redis
{
    public class RedisWebConnection : CacheModule
    {
        public RedisWebConnection(string host = "localhost", int port = 80, string password = null, long db = 0) : base(host, port, password, db)
        {
            Host = host;
            Port = port;
            cacheType = CacheType.Cloud_Redis;
        }

        protected string GetClient()
        {
#if DNX451 || NET451
            HttpWebRequest h = HttpWebRequest.Create("");
            var s = WebRequest.Create("");
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif

            return null;
        }

        protected string GetUrl() => $"{Host}:{Port}";


    }
}
