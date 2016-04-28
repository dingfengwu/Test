using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Cache.Model
{
    public class InfoKeyModel: IEntity<InfoKeyModel>
    {
        public IdType type;
        public string id;

        public override string ToString() => $"{type}-{id}.";
    }

    public enum IdType
    {
        /// <summary>
        /// user
        /// </summary>
        U,
        /// <summary>
        /// App
        /// </summary>
        A,
        /// <summary>
        /// Module
        /// </summary>
        M,
        /// <summary>
        /// other
        /// </summary>
        O
    }
}
