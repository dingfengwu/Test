using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Redis.Model
{
    public class PostSetData<T>:PostSetTimeData
    {
        public T value { get; set; }

        
            
    }
}
