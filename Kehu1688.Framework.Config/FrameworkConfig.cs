using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Config
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class FrameworkConfig
    {
        static IocConfig _iocConfig;
        static object _lock = new object();

        /// <summary>
        /// 全局注入配置
        /// </summary>
        public static IocConfig IocConfig
        {
            get
            {
                lock (_lock)
                {
                    if (_iocConfig == null)
                    {
                        _iocConfig = new IocConfig();
                    }
                }
                return _iocConfig;
            }
        }

        /// <summary>
        /// 获取配置文件中的配置
        /// </summary>
        public static IConfigurationRoot Settings
        {
            get
            {
               return IocConfig.Resolve<IConfigurationRoot>();
            }
        }
    }
}
