/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：SqlHelper.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-22 10:55:32
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    /// <summary>
    /// SQLHelper
    /// </summary>
    public class SqlHelper : DbHelper
    {
        const string _providerName = "MSSQLSERVER";

        public SqlHelper()
        {

        }

        public SqlHelper(string connectionString)
        {
            WriteableConnectionString = connectionString;
        }
        
        public override string DbProviderName
        {
            get
            {
                return _providerName;
            }
        }

        protected override DbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        protected override DbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
