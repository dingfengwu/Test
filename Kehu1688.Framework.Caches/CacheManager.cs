/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：CacheManager.cs
// 文件功能描述：
// 缓存模块管理器
//
// 创建人  ：WZJ
// 创建日期：2016-04-04 9:12:00
//----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kehu1688.Framework;
using Kehu1688.Framework.Base.Cache;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Configuration;
using Kehu1688.Framework.Config;

namespace Kehu1688.Framework.Cache
{
    public  class CacheManager
    {
        /// <summary>
        /// 系统缓存模块调度
        /// </summary>
        public static Dictionary<string, CacheModule> Syslist { get; set; }

        /// <summary>
        /// 应用缓存模块调度
        /// </summary>
        public static Dictionary<string, CacheModule> Applist { get; set; }

        /// <summary>
        /// 用户缓存调度
        /// </summary>
        public static Dictionary<string, CacheModule> Userlist { get; set; }

        static CacheManager()
        {
            Syslist = new Dictionary<string, CacheModule>();
            Applist = new Dictionary<string, CacheModule>();
            Userlist = new Dictionary<string, CacheModule>();
            //进入配置文件获取连接状态
            //var builder = new ConfigurationBuilder()
            //  .AddJsonFile("appsettings.json")
            //  .AddEnvironmentVariables();
            //Configuration = builder.Build();
            //var sys = Configuration["CacheServer:SysServer"];
            //var app = Configuration["CacheServer:AppServer"];
            //var user = Configuration["CacheServer:UserServer"];

            var config = FrameworkConfig.IocConfig.Resolve<IConfiguration>();
            var s = config["aa_bb"];
        }


        //public string Get()
        //{

        //    var sys = Configuration["CacheServer:SysServer"];
        //    var app = Configuration["CacheServer:AppServer"];
        //    var user = Configuration["CacheServer:UserServer"];
        //    return $"1:{sys} 2:{app} 3:{user}";
        //}
        public IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="ItmeName"></param>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static CacheReturnData<T> SetCache<T>(T data, string key)
        {
            CacheReturnData<T> cd = new CacheReturnData<T>();
            try
            {
                CacheModule cm = new CacheModule();
                cd.reult = cm.Set(key, data);
                cd.data = data;

            }
            catch
            {
                cd.reult = false;
                cd.data = default(T);
            }
            return cd;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ItmeName"></param>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static CacheReturnData<T> GetCache<T>(string key)
        {
            CacheReturnData<T> cd = new CacheReturnData<T>();
            try
            {
                CacheModule cm = new CacheModule();
                if (cm.Exists( key))
                {

                    cd.data = cm.Get<T>(key);
                    cd.reult = true;
                }
                else
                {
                    cd.reult = false;
                    cd.data = default(T);
                }
            }
            catch
            {
                cd.reult = false;
                cd.data = default(T);
            }
            return cd;
        }

        /// <summary>
        /// 缓存统计
        /// </summary>
        /// <returns></returns>
        public static CacheReturnData<long> CacheCount()
        {
            CacheReturnData<long> cd = new CacheReturnData<long>();
            try
            {
                CacheModule cm = new CacheModule();
                cd.data = cm.KeysNum();
                cd.reult = true;
            }
            catch
            {
                cd.reult = false;
                cd.data = 0;
            }
            return cd;
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="ItmeName"></param>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static CacheReturnData<long> DelCache(string key)
        {
            CacheReturnData<long> cd = new CacheReturnData<long>();
            try
            {
                CacheModule cm = new CacheModule();
                cd.data = cm.Delete(key);
                cd.reult = true;
            }
            catch
            {
                cd.reult = false;
                cd.data = -1;
            }
            return cd;
        }

        public static CacheReturnData<long> TryDelCache(string pattrm)
        {
            CacheReturnData<long> cd = new CacheReturnData<long>();
            try
            {
                CacheModule cm = new CacheModule();
                cd.data = cm.Delete(pattrm);
                cd.reult = true;
            }
            catch
            {
                cd.reult = false;
                cd.data = 0;
            }
            return cd;
        }

        public static CacheReturnData<Dictionary<string,string>> ServerModuleInfo()
        {
            CacheReturnData<Dictionary<string, string>> cd = new CacheReturnData<Dictionary<string, string>>();
            try
            {
                CacheModule cm = new CacheModule();
                cd.data = cm.ServerInfo();
                cd.reult = true;
            }
            catch
            {
                cd.reult = false;
                cd.data = new Dictionary<string,string>();
            }
            return cd;
        }

        /// <summary>
        /// Id类型
        /// </summary>
        public enum IdType
        {
            None = 0,
            User,
            Power,
            Role,
            Module
        }


    }
}
