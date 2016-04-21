using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kehu1688.Framework.Base;

namespace Kehu1688.Framework.Redis.Model
{
    public class PostVerifyIdentity:PostData
    {
        public long nowtime { get; set; }

        public string secret { get
            {
                return app.GetSHA256(nowtime.ToString());
            }
        }

        public PostVerifyIdentity()
        {
            nowtime = DateTime.Now.Timestamp();
        }
    }
}
