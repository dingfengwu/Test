using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Cache.Model
{
    public class TableKeyModel: IEntity<TableKeyModel>
    {
        public string table;
        public string id;

        public override string ToString() => $"t{table}-{id}.";
    }
}
