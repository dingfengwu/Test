using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Store
{
    public abstract class DbHelper
    {
        string _writeableConnectionString;
        DbConnection _writeableConnection;
        string _readonlyConnectionString;
        DbConnection _readonlyConnection;
        object _lock = new object();
        
        /// <summary>
        /// 可写的连接字符串
        /// </summary>
        public string WriteableConnectionString
        {
            get
            {
                return _writeableConnectionString;
            }
            set
            {
                _writeableConnectionString = value;
            }
        }

        /// <summary>
        /// 只读的连接字符串
        /// </summary>
        public string ReadonlyConnectionString
        {
            get
            {
                lock (_lock)
                {
                    if (_readonlyConnectionString == null)
                        _readonlyConnectionString = ConnectionStringManager.GetReadOnlyConnectionString();
                }
                return _readonlyConnectionString;
            }
        }

        /// <summary>
        /// 创建一个新的DbConnection对象
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        protected abstract DbConnection CreateConnection(string connectionString);

        /// <summary>
        /// 创建一个新的DbCommand对象
        /// </summary>
        /// <returns></returns>
        protected abstract DbCommand CreateCommand();

        /// <summary>
        /// 获取当前数据提供程序名称
        /// </summary>
        public abstract string DbProviderName { get; }

        /// <summary>
        /// 可写的连接
        /// </summary>
        /// <returns></returns>
        protected DbConnection CreaeWriteableConnection()
        {
            lock (_lock)
            {
                if (_writeableConnection == null)
                {
                    _writeableConnection = CreateConnection(_writeableConnectionString);
                }
            }

            if (_writeableConnection.State == ConnectionState.Closed)
                _writeableConnection.Open();

            return _writeableConnection;
        }

        /// <summary>
        /// 只读的连接
        /// </summary>
        /// <returns></returns>
        protected DbConnection CreateReadonlyConnection()
        {
            lock (_lock)
            {
                if (_readonlyConnection == null)
                {
                    _readonlyConnection = CreateConnection(ReadonlyConnectionString);
                }
            }

            if (_readonlyConnection.State == ConnectionState.Closed)
                _readonlyConnection.Open();

            return _readonlyConnection;
        }
        
        /// <summary>
        /// 创建command
        /// </summary>
        /// <param name="sql">sql语句，包括存储过程名称</param>
        /// <param name="type">command类型</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected DbCommand CreateCommand(string sql, CommandType type, DbParameter[] parameters)
        {
            DbCommand command = CreateCommand();

            command.CommandType = type;
            command.CommandTimeout = 5 * 60;
            command.CommandText = sql;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
                command.Parameters.AddRange(parameters);
            }

            return command;
        }

        /// <summary>
        /// 执行sql语句或存储过程程
        /// </summary>
        /// <param name="sql">sql语句，包括存储过程名称</param>
        /// <param name="type">command类型</param>
        /// <param name="parameters">参数</param>
        /// <returns>影响行数</returns>
        public async Task<int> ExecuteNonQuery(string sql, CommandType type, params DbParameter[] parameters)
        {
            DbConnection conn = CreaeWriteableConnection();
            DbCommand cmd = CreateCommand(sql, type, parameters);
            cmd.Connection = conn;
            try
            {
                int rows = await cmd.ExecuteNonQueryAsync();
                return rows;
            }
            finally
            {
                cmd.Dispose();
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// 执行sql语句或存储过程程
        /// </summary>
        /// <param name="sql">sql语句，包括存储过程名称</param>
        /// <param name="type">command类型</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回DataReader,需要自行处理关闭</returns>
        public async Task<DbDataReader> ExecuteReader(string sql, CommandType type, params DbParameter[] parameters)
        {
            DbConnection conn = CreaeWriteableConnection();
            DbCommand cmd = CreateCommand(sql, type, parameters);
            cmd.Connection = conn;
            try
            {
                var reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (DbException)
            {
                cmd.Dispose();
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 执行sql语句或存储过程程
        /// </summary>
        /// <param name="sql">sql语句，包括存储过程名称</param>
        /// <param name="type">command类型</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回DataReader,需要自行处理关闭</returns>
        public async Task<DbDataReader> ExecuteReaderWithReadonlyDb(string sql, CommandType type, params DbParameter[] parameters)
        {
            DbConnection conn = CreateReadonlyConnection();
            DbCommand cmd = CreateCommand(sql, type, parameters);
            cmd.Connection = conn;
            try
            {
                var reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (DbException)
            {
                cmd.Dispose();
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 执行sql语句或存储过程程
        /// </summary>
        /// <param name="sql">sql语句，包括存储过程名称</param>
        /// <param name="type">command类型</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回DataReader,需要自行处理关闭</returns>
        public async Task<object> ExecuteScalar(string sql, CommandType type, params DbParameter[] parameters)
        {
            DbConnection conn = CreaeWriteableConnection();
            DbCommand cmd = CreateCommand(sql, type, parameters);
            cmd.Connection = conn;
            try
            {
                var obj = await cmd.ExecuteScalarAsync();
                return obj;
            }
            finally
            {
                cmd.Dispose();
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// 执行sql语句或存储过程程
        /// </summary>
        /// <param name="sql">sql语句，包括存储过程名称</param>
        /// <param name="type">command类型</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回DataReader,需要自行处理关闭</returns>
        public async Task<object> ExecuteScalarWithReadonlyDb(string sql, CommandType type, params DbParameter[] parameters)
        {
            DbConnection conn = CreateReadonlyConnection();
            DbCommand cmd = CreateCommand(sql, type, parameters);
            cmd.Connection = conn;
            try
            {
                var obj = await cmd.ExecuteScalarAsync();
                return obj;
            }
            finally
            {
                cmd.Dispose();
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

    }
}
