/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：UserLog.cs
// 文件功能描述：
// 用户日志实体类
//
// 创建人  ：WZJ
// 创建日期：2016-04-23 10:40:00
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kehu1688.Framework.Base;

namespace Kehu1688.Framework.Permission.Model
{
    public class UserLog:IEntity<UserLog>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long id { get; set;}
        
        /// <summary>
        /// 用户id
        /// </summary>
        public string userId { get; set;}

        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set;}

        /// <summary>
        /// ip地址
        /// </summary>
        public string ipAddress { get; set;}

        /// <summary>
        /// 浏览器
        /// </summary>
        public string browser { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        public string account { get; set;}

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime oprTime { get; set;}

        /// <summary>
        /// 所属模块
        /// </summary>
        public string module { get; set;}

        /// <summary>
        /// 所属应用
        /// </summary>
        public string app { get; set;}

        /// <summary>
        /// 操作类型
        /// </summary>
        public string oprType { get; set;}

        /// <summary>
        /// 影响
        /// </summary>
        public string influence { get; set;}

        /// <summary>
        /// 结果
        /// </summary>
        public string result { get; set;}

        /// <summary>
        /// 操作数据项
        /// </summary>
        public string oprData { get; set;}

        /// <summary>
        /// 操作
        /// </summary>
        public string operation { get; set;}

        /// <summary>
        /// 是否可以恢复
        /// </summary>
        public bool isRecovery { get; set;}

        /// <summary>
        /// 是否已经恢复
        /// </summary>
        public bool isRecoveryed { get; set;}

        /// <summary>
        /// 当前状态
        /// </summary>
        public int state { get; set;}
        
        /// <summary>
        /// 获取操作数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public UserLogViewModel<T> GetOprData<T>()
        {
            if (oprData != null)
            {
                try
                {
                    return CommonExtenstion.ToJson<UserLogViewModel<T>>(oprData);
                }
                catch
                {
                    return new UserLogViewModel<T>();
                }
            }
            else
            {
                return new UserLogViewModel<T>();
            }

        }

        /// <summary>
        /// 设置操作数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tName"></param>
        /// <param name="fName"></param>
        /// <param name="dType"></param>
        /// <param name="sdata"></param>
        /// <param name="chdata"></param>
        /// <returns></returns>
        public bool SetOprData<T>(string tName,string fName,string dType,T sdata,T chdata)
        {
            try {
                var data = new UserLogViewModel<T>();
                data.tableName = tName;
                data.FieldName = fName;
                data.dataType = dType;
                data.sourceValue = sdata;
                data.changeValue = chdata;
                oprData = data.ToJson();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
