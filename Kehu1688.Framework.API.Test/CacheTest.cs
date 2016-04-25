using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text;
using System.Net.Http;
using System.Net;
using Kehu1688.Framework.Redis;

namespace Kehu1688.Framework.API.Test
{
    public class CacheTest
    {
        [Fact]
        public void GetCache()
        {
            int a = 0;
            a++;
            RedisWebConnection rc = new RedisWebConnection("10.0.169.83",8888);
            var dd = rc.ServerInfo();
            Console.Write(a);
            Assert.Equal(a , 32);
        }

        
    }
}
