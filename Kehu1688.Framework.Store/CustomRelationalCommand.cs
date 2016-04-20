/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：CusRelationalCommand.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-19 11:17:42
//----------------------------------------------------------------*/



using Kehu1688.Framework.Base;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Storage;
using Microsoft.Data.Entity.Storage.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Kehu1688.Framework.Config;
using System.Data.SqlClient;
using Microsoft.Data.Entity;

namespace Kehu1688.Framework.Store
{
    public class CustomRelationalCommand: RelationalCommand
    {
        ILogger _logger;

        public CustomRelationalCommand(
            [NotNull] ISensitiveDataLogger logger,
            [NotNull] DiagnosticSource diagnosticSource,
            [NotNull] string commandText,
            [NotNull] IReadOnlyList<RelationalParameter> parameters):base(logger,diagnosticSource,commandText,parameters)
        {
            _logger = logger;
        }

        protected override T Execute<T>(IRelationalConnection connection, Func<DbCommand, IRelationalConnection, T> action,string executeMethod, bool openConnection, bool closeConnection)
        {
            var dbCommand = CreateCommand(connection);
            
            T result;

            if (openConnection)
            {
                connection.Open();
            }

            try
            {
                result = action(dbCommand, connection);
            }
            catch (Exception)
            {
                if (openConnection && !closeConnection)
                {
                    connection.Close();
                }

                throw;
            }
            finally
            {
                if (closeConnection)
                {
                    connection.Close();
                }
            }

            return result;
        }


        protected override async Task<T> ExecuteAsync<T>(IRelationalConnection connection,  Func<DbCommand, IRelationalConnection, CancellationToken, Task<T>> action,string executeMethod, bool openConnection, bool closeConnection, CancellationToken cancellationToken = default(CancellationToken))
        {
            var dbCommand = CreateCommand(connection);
            T result;

            if (openConnection)
            {
                await connection.OpenAsync(cancellationToken);
            }
            
            try
            {
                result = await action(dbCommand, connection, cancellationToken);
            }
            catch (Exception)
            {
                if (openConnection && !closeConnection)
                {
                    connection.Close();
                }

                throw;
            }
            finally
            {
                if (closeConnection)
                {
                    connection.Close();
                }
            }
            return result;
        }

        private DbCommand CreateCommand(IRelationalConnection connection)
        {
            DbCommand command = null;
            if (CommandText.IndexOf("INSERT", StringComparison.CurrentCultureIgnoreCase) < 0 &&
                CommandText.IndexOf("UPDATE", StringComparison.CurrentCultureIgnoreCase) < 0)
            {
                if (connection.GetType() == typeof(SqlServerConnection))
                {
                    var connectionString = ConnectionStringManager.GetReadOnlyConnectionString();
                    var builder = new SqlConnectionStringBuilder { ConnectionString = connectionString};
                    var optionsBuilder = new DbContextOptionsBuilder();
                    optionsBuilder.UseSqlServer(builder.ConnectionString);

                    var loggerFactory = FrameworkConfig.IocConfig.Resolve<ILoggerFactory>();
                    Logger <SqlServerConnection> logger = new Logger<SqlServerConnection>(loggerFactory);
                    var conn = new SqlServerConnection(optionsBuilder.Options, logger);
                    connection = conn;
                    if (connection.DbConnection.State == System.Data.ConnectionState.Closed)
                    {
                         connection.DbConnection.Open();
                    }
                    command = conn.DbConnection.CreateCommand();
                }
                else
                {
                    _logger.LogWarning(Resource.ResourceManager.GetString("WARN_NOT_SUPPORT_READ_WRITE_SPLIT"));
                    command = connection.DbConnection.CreateCommand();
                }
            }
            else {
                command = connection.DbConnection.CreateCommand();
            }
            command.CommandText = CommandText;

            if (connection.Transaction != null)
            {
                command.Transaction = connection.Transaction.GetInfrastructure();
            }

            if (connection.CommandTimeout != null)
            {
                command.CommandTimeout = (int)connection.CommandTimeout;
            }

            foreach (var parameter in Parameters)
            {
                command.Parameters.Add(
                    parameter.RelationalTypeMapping.CreateParameter(
                        command,
                        parameter.Name,
                        parameter.Value,
                        parameter.Nullable));
            }

            return command;
        }
    }
}
