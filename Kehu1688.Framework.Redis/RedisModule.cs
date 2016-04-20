using Kehu1688.Framework.Base.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace Kehu1688.Framework.Redis
{
    public class RedisModule:CacheModule
    {        
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public RedisModule(string host = "localhost", int port = 6379, string password = null, long db = 0) : base(host, port, password, db)
        {
            Host = host;
            Port = port;
            cacheType = CacheType.Redis;
        }

        /// <summary>
        /// 获取连接后的客户端对象
        /// </summary>
        /// <returns></returns>
        protected  RedisClient GetClient() => new RedisClient(Host, Port, Password, DB);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value">不容许为null</param>
        /// <returns></returns>
        public override bool Set<T>(string key, T value)
        {
            using (var rc = GetClient())
            {
                return rc.Set<T>(key, value);
            }
        }

        /// <summary>
        /// 设置缓存，且指定到期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresAt">到期时间</param>
        /// <returns></returns>
        public override bool Set<T>(string key, T value,DateTime expiresAt)
        {
            using (var rc = GetClient())
            {
                return rc.Set<T>(key, value, expiresAt);
            }
        }

        /// <summary>
        /// 设置缓存，且指定到期时间段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn">到期时间段</param>
        /// <returns></returns>
        public override bool Set<T>(string key, T value,TimeSpan expiresIn)
        {
            using (var rc = GetClient())
            {
                return rc.Set<T>(key, value, expiresIn);
            }
        }

        /// <summary>
        /// 不带值则删除key对应的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool Set(string key)
        {
            var r = Delete(key);
            return r >= 0;
        }

        /// <summary>
        /// 根据key获取缓存值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public override T Get<T>(string key)
        {
            using (var rc = GetClient())
            {
                return rc.Get<T>(key);
            }
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool Exists(string key)
        {
            using (var rc = GetClient())
            {
                return rc.Exists(key) >= 0;
            }
        }

        /// <summary>
        /// 根据key获取缓存记录id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override long KeyId(string key)
        {
            using (var rc = GetClient())
            {
                return rc.Exists(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override long KeysNum()
        {
            using (var rc = GetClient())
            {
                return rc.DbSize;
            }
        }

        /// <summary>
        /// 获取服务器版本号
        /// </summary>
        /// <returns></returns>
        public override string ServerVersion()
        {
            using (var rc = GetClient())
            {
                return rc.ServerVersion;
            }

        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public override void FlushAll()
        {
            using (var rc = GetClient())
            {
                rc.FlushAll();
            }
        }

        /// <summary>
        /// 根据key来删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override long Delete(params string[] key)
        {
            using (var rc = GetClient())
            {
                return rc.Del(key);
            }
        }

        
    }
}
