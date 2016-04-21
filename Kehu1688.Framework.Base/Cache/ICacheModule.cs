using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base.Cache
{
    public interface ICacheModule:IEntity<ICacheModule>
    {

        bool Set<T>(string key, T value);

        bool Set(string key);

        bool Set<T>(string key, T value, DateTime expiresAt);


        bool Set<T>(string key, T value, TimeSpan expiresIn);

        T Get<T>(string key);

        bool Exists(string key);

        long KeyId(string key);

        long KeysNum();

        string ServerVersion();

        void FlushAll();

        long Delete(params string[] key);

        bool Expire(string key, int s);

        long LPush(string key, byte[] s);

        void FlushDB();

        byte[] RPop(string key);

        byte[] RPopLPush(string key);

        byte[] RPopLPush(string fromkey, string tokey);

        List<string> Keys(string pattern);
        
        long TTL(string key);
        
        long PTTL(string key);
        
        bool Move(string key, int db);

        Dictionary<string, string> ServerInfo();
    }
}
