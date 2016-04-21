/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：PostVerifyIdentity.cs
// 文件功能描述：
// Redis参数尝试匹配类 属性：app nowtime secret
//
// 创建人  ：WZJ
// 创建日期：2016-04-21 15:42:00
//----------------------------------------------------------------*/

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
