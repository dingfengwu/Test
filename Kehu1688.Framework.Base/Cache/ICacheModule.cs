using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base.Cache
{
    public interface ICacheModule
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
    }
}
