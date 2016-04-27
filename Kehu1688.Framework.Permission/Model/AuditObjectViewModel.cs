

using Kehu1688.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission.Model
{
    public class AuditObjectViewModel: IEntity<AuditObjectViewModel>
    {
        /// <summary>
        /// 所属表，或id所属类型
        /// </summary>
        public string table { get; set; }

        /// <summary>
        /// 指定所属表下的id
        /// </summary>
        public int id { get; set; }
    }
}
