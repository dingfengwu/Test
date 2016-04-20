/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：CommandInterceptor.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-18 17:26:58
//----------------------------------------------------------------*/



using Kehu1688.Framework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    public static class ConnectionStringManager
    {
        static ConnectionStringManager()
        {
            CancellationToken = new CancellationToken(false);
            readConnList = DistributedReadWriteManager.Instance;
            StartHeartMessage();
        }

        private static void StartHeartMessage()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    KeepLiveConnectionString();
                    Thread.Sleep(sysTimer);
                }
            }, CancellationToken);
        }

        /// <summary>
        /// 取消Token
        /// </summary>
        public static CancellationToken CancellationToken { get; set; }
        
        /// <summary>
        /// 锁住它
        /// </summary>
        private static object lockObj = new object();
        /// <summary>
        /// 定期找没有在线的数据库服务器
        /// </summary>
        private static TimeSpan sysTimer = TimeSpan.FromSeconds(5);
        /// <summary>
        ///　读库，从库集群，写库不用设置走默认的EF框架
        /// </summary>
        private static IList<DbConnectionOption> readConnList;
        
        private static void KeepLiveConnectionString()
        {
#if DNX451 || NET451
            if (readConnList != null && readConnList.Any())
            {
                foreach (var item in readConnList)
                {
                    //心跳测试，将死掉的服务器IP从列表中移除
                    var client = new TcpClient();
                    
                    try
                    {
                        client.Connect(new IPEndPoint(IPAddress.Parse(item.IP), item.Port));
                    }
                    catch (SocketException)
                    {
                        
                    }
                    if (!client.Connected)
                    {
                        lock (lockObj)
                        {
                            readConnList.Remove(item);
                        }
                    }
                }
            }
#elif DNXCORE50 || NET50
            throw new Exception("not support this method");
#endif
        }

        /// <summary>
        /// 处理读库字符串
        /// </summary>
        /// <returns></returns>
        public static string GetReadOnlyConnectionString()
        {
            if (readConnList != null && readConnList.Any())
            {
                var resultConn = readConnList[Convert.ToInt32(Math.Floor((double)new Random().Next(0, readConnList.Count)))];
                return string.Format(FrameworkConfig.Settings["Data:Connections:ReadConnectionString"]
                    , resultConn.IP
                    , resultConn.Port
                    , resultConn.DbName
                    , resultConn.UserId
                    , resultConn.Password);
            }
            return string.Empty;
        }
    }
}
