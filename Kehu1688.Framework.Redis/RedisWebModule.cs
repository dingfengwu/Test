using Kehu1688.Framework.Base.Cache;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Redis
{
    public class RedisWebModule : CacheModule
    {
        public RedisWebModule(string host = "localhost", int port = 80, string password = null, long db = 0) : base(host, port, password, db)
        {
            Host = host;
            Port = port;
            cacheType = CacheType.Cloud_Redis;
        }

        protected string GetClient()
        {
           
            return null;
        }

        protected string GetUrl() => $"{Host}:{Port}";
    }
}
