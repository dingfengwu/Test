/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：RedisConnection.cs
// 文件功能描述：
// Redis 模块连接和调用
//
// 创建人  ：WZJ
// 创建日期：2016-04-12 14:13:00
//----------------------------------------------------------------*/

using Kehu1688.Framework.Base.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.Redis;
using System.Text;

namespace Kehu1688.Framework.Redis
{
    public class RedisConnection:CacheModule
    {        
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public RedisConnection(string host = "localhost", int port = 6379, string password = null, long db = 0) : base(host, port, password, db)
        {
            Host = host;
            Port = port;
            cacheType = CacheType.Redis;
        }
#if DNX451 || NET451
        /// <summary>
        /// 获取连接后的客户端对象
        /// </summary>
        /// <returns></returns> 
        protected  RedisClient GetClient() => new RedisClient(Host, Port, Password, DB);

        
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value">不容许为null</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Set<T>(key, value);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif

        }


        public bool Set<T>(string key, T value,DateTime time)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Set<T>(key, value,time);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 不带值则删除key对应的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Set(string key)
        {
#if DNX451 || NET451
            var r = Delete(key);
            return r >= 0;
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 根据key获取缓存值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Get<T>(key);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Exists(key) > 0;
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 根据key获取缓存记录id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long KeyId(string key)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Exists(key); 
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long KeysNum()
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.DbSize;
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 获取服务器版本号
        /// </summary>
        /// <returns></returns>
        public string ServerVersion()
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.ServerVersion;
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        public void FlushAll()
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {   
                rc.FlushAll();
                //
                //rc.GetServerRole()
                //rc.GetServerRoleInfo()
                //rc.GetServerTime()
                
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        public void FlushDB()
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                rc.FlushDb();

            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 根据key来删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Delete(params string[] key)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Del(key);                
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 设置生成时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Expire(string key, int s)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Expire(key, s);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        public long LPush(string key, byte[] s)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.LPush(key, s);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        public byte[] RPop(string key)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.RPop(key);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        public byte[] RPopLPush(string key)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.RPopLPush(key,key);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        public byte[] RPopLPush(string fromkey,string tokey)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.RPopLPush(fromkey, tokey);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 获取存在的Key的值
        /// </summary>
        /// <param name="pattern">
        /// KEYS * 匹配数据库中所有 key 。
        /// KEYS h?llo 匹配 hello ， hallo 和 hxllo 等。
        /// KEYS h*llo 匹配 hllo 和 heeeeello 等。
        /// KEYS h[ae]llo 匹配 hello 和 hallo ，但不匹配 hillo
        /// </param>
        /// <returns></returns>
        public List<string> Keys(string pattern)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                var bs = rc.Keys(pattern);
                List<string> list = new List<string>();
                foreach (var b in bs)
                {
                    list.Add(Encoding.Default.GetString(b));
                }
                return list;
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 获取key剩余生存时间，秒为单位
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long TTL(string key)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Ttl(key);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 获取key剩余生成时间，毫秒为单位
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long PTTL(string key)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.PTtl(key);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 移动key-value到指定db内
        /// </summary>
        /// <param name="key"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool Move(string key ,int db)
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Move(key, db);
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 获取服务器信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> ServerInfo()
        {
#if DNX451 || NET451
            using (var rc = GetClient())
            {
                return rc.Info;
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }
    }
}
