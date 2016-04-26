using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text;
using System.Net.Http;
using System.Net;
using Kehu1688.Framework.UserLog;

namespace Kehu1688.Framework.API.Test
{
    public class LogTest
    {
        [Fact]
        public void AddLog()
        {
            LogMenager lm = new LogMenager();
            var m = new Permission.Model.UserLog()
            {
                id = 10,
                account = "zhanghao123456",
                app = "frametest",
                browser = "no",
                ipAddress = "10.0.1.12",
                module = "logtest",
                userId = "asdasdasdadasdad",
                influence = "",
                oprTime = DateTime.Now,
                operation = "add log test",
                isRecovery = true,
                isRecoveryed = false,
                oprType = "json",
                userName = "wzj",
                result = "adadddd",
                state = 1
            };
            var ss = new { name = "zhangsan", age = 23 };
            var cc = new { name = "lisi", age = 33 };
            m.SetOprData("tt", "ff", "aa", ss, cc);
            lm.Writer(m);

            
        }

        
    }
}
