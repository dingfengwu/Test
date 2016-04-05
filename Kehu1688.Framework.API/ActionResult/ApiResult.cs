using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.API
{
    public abstract class ApiResult
    {
        public bool Result { get; set; } = true;
    }
}
