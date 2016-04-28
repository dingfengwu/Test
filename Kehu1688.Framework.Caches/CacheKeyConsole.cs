using Kehu1688.Framework.Base;
using Kehu1688.Framework.Cache.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Cache
{
    public class CacheKeyConsole: IEntity<CacheKeyConsole>
    {
        public List<TableKeyModel> tables { get; set; }

        public List<InfoKeyModel> info { get; set; }

        public string Itme { get; set; }

        /// <summary>
        /// key生成
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            string key = string.Empty;
            if (tables.Count > 0)
            {
                foreach(var t in tables)
                {
                    key = key + t.ToString();
                }
            }
            if (info.Count > 0)
            {
                foreach (var u in info)
                {
                    key = key + u.ToString();
                }
            }
            key = key.TrimEnd('.');
            key = $"{key}={Itme}";
            return key;
        }

        public CacheKeyConsole()
        {
            tables = new List<TableKeyModel>();            
            info = new List<InfoKeyModel>();
            //此处随机生成
            Itme = Guid.NewGuid().ToString().Substring(10,5);
        }
    }
}
