/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：DbConfigureManager.cs
// 文件功能描述：
// 数据库
//
// 创建人  ：WDF
// 创建日期：2016-04-22 16:04:26
//----------------------------------------------------------------*/



using Kehu1688.Framework.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    public class DbConfigureManager
    {
        string _providerName;
        
        public DbConfigureManager()
        {
            _providerName = FrameworkConfig.IocConfig.Resolve<DbHelper>().DbProviderName;
        }

        /// <summary>
        /// 从资源文件中获取sql语句
        /// </summary>
        /// <param name="key"></param>
        /// <param name="resourceManager"></param>
        /// <returns></returns>
        public Task<string> Read(string key, ResourceManager resourceManager)
        {
            string line = string.Empty;
            var filename = string.Empty;
            var indexFilename = _providerName.ToLower() + "_index";
            var sqlFilename = _providerName.ToLower();
            
            var index=resourceManager.GetString(indexFilename);
            filename = QueryKeyByContent(index, key);
            if (!string.IsNullOrWhiteSpace(filename)) sqlFilename = filename;
            var content = resourceManager.GetString(sqlFilename);
            var result = QueryContentByKey(content, key);
            return Task.FromResult(result);
        }

        /// <summary>
        /// 通过内容查询key
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="keyword">内容关键词(内容必须是以","号分隔的关键词)</param>
        private string QueryKeyByContent(string content, string keyword)
        {
            if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(keyword)) return null;

            var firstRow = "";
            var startPoint = -1;
            StringBuilder item = new StringBuilder();
            foreach (var line in content.Split('\n'))
            {
                if (line.Trim().StartsWith("#")) continue;
                if (line.Trim() == string.Empty)
                {
                    item.Clear();
                    continue;
                }
                if (item.Length == 0) firstRow = line.Trim();
                item.AppendLine(line.Trim());

                if (line.Split(',').Contains(keyword))
                {
                    startPoint = firstRow.IndexOf("=");
                    if (startPoint > 0)
                        return firstRow.Substring(0, startPoint);
                    break;
                }
            }
            return null;
        }

        /// <summary>
        /// 通过key找内容
        /// </summary>
        /// <param name="content"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private string QueryContentByKey(string content, string key)
        {
            bool hasKey = false;
            StringBuilder item = new StringBuilder();
            foreach (var line in content.Split('\n'))
            {
                if (line.Trim().StartsWith("#")) continue;
                if (line.Trim() == string.Empty)
                {
                    if (!hasKey)
                    {
                        item.Clear();
                    }
                    else {
                        return item.ToString();
                    }
                    continue;
                }
                
                if (line.Split('=').Contains(key) && item.Length == 0)
                {
                    hasKey = true;
                }

                if (hasKey)
                {
                    item.AppendLine(line.Trim());
                }
            }
            if (hasKey) return item.ToString();
            return null;
        }
    }
}
