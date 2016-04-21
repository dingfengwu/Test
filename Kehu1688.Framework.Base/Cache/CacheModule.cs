using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base.Cache
{
    public class CacheModule : ICacheModule
    {
        #region 属性
        /// <summary>
        /// 记录模块的缓存类型
        /// </summary>
        public static CacheType cacheType=CacheType.None;
        /// <summary>
        /// 缓存服务主键号
        /// </summary>
        public string Host;
        /// <summary>
        /// 缓存服务接口号
        /// </summary>
        public int Port;
        /// <summary>
        /// 访问密码
        /// </summary>
        public string Password;
        /// <summary>
        /// 缓存数据库
        /// </summary>
        public long DB;
        #endregion

        #region 方法

        public CacheModule(string host = null,int port = 0 , string password = null,long db = 0)
        {
            Host = host;
            Port = port;
            Password = password;
            DB = db;
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual long Delete(params string[] key)
        {
            return -1;
        }


        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public virtual void FlushAll()
        {
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual bool Exists(string key)
        {
            return false;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T Get<T>(string key)
        {
            return default(T);
        }

        /// <summary>
        /// 获取key的id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual long KeyId(string key)
        {
            return -1;
        }

        /// <summary>
        /// 获取当前key的总数
        /// </summary>
        /// <returns></returns>
        public virtual long KeysNum()
        {
            return -1;
        }


        /// <summary>
        /// 获取缓存服务版本
        /// </summary>
        /// <returns></returns>
        public virtual string ServerVersion()
        {
            return null;
        }

        /// <summary>
        /// 快速删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual bool Set(string key)
        {
            return false;
        }

        /// <summary>
        /// 设置或添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool Set<T>(string key, T value)
        {
            return false;
        }

        /// <summary>
        /// 设置缓存，且指定到期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresAt">到期时间</param>
        /// <returns></returns>
        public virtual bool Set<T>(string key, T value, DateTime expiresAt)
        {
            return false;
        }

        /// <summary>
        /// 设置缓存，且指定到期时间段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn">期时间段</param>
        /// <returns></returns>
        public virtual bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            return false;
        }

        public bool Expire(string key, int s)
        {
            return false;
        }

        public long LPush(string key, byte[] s)
        {
            return 0;
        }

        public void FlushDB()
        { 
        }

        public byte[] RPop(string key)
        {
            return default(byte[]);
        }

        public byte[] RPopLPush(string key)
        {
            return default(byte[]);
        }

        public byte[] RPopLPush(string fromkey, string tokey)
        {
            return default(byte[]);
        }

        public List<string> Keys(string pattern)
        {
            return new List<string>();
        }

        public long TTL(string key)
        {
            return 0;
        }

        public long PTTL(string key)
        {
            return 0;
        }

        public bool Move(string key, int db)
        {
            return false;
        }

        public Dictionary<string, string> ServerInfo()
        {
            return default(Dictionary<string, string>);
        }


        #endregion
    }
}
