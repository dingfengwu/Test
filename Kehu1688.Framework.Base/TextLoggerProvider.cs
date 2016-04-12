/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：TxtLoggerProvider.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 11:01:39
//----------------------------------------------------------------*/



using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Base
{
    public class TextLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new TextLogger();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~TextLoggerProvider() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion

    }

    public class TextLogger : DefaultLogger
    {
        FileInfo _verboseFile;
        FileInfo _errorFile;
        FileInfo _warningFile;
        TextLoggerOption _options;
        object _lock = new object();

        public TextLogger(TextLoggerOption options)
        {
            _options = options;
            if (!Directory.Exists(options.LoggerPath))
                Directory.CreateDirectory(options.LoggerPath);
        }

        
        private FileInfo VerboseFile
        {
            get
            {
                lock(_lock)
                {
                    if (_verboseFile == null)
                        _verboseFile = new FileInfo(LogFilename(LogLevel.Verbose));
                }
                return _verboseFile;
            }
        }

        private FileInfo WarningFile
        {
            get
            {
                lock (_lock)
                {
                    if (_warningFile == null)
                        _warningFile = new FileInfo(LogFilename(LogLevel.Verbose));
                }
                return _warningFile;
            }
        }

        private FileInfo ErrorFile
        {
            get
            {
                lock (_lock)
                {
                    if (_errorFile == null)
                        _errorFile = new FileInfo(LogFilename(LogLevel.Verbose));
                }
                return _errorFile;
            }
        }

        public string LogFilename(LogLevel logLevel)
        {
            return Path.Combine(_options.LoggerPath, $"{logLevel.ToString()}{DateTime.Now.ToString("yyyyMMdd")}.log");
        }

        public override IDisposable BeginScopeImpl(object state)
        {
            throw new NotImplementedException();
        }

        protected override string Formatter(object state, Exception exception)
        {
            return string.Format($"时间:{DateTime.Now.ToString("HH:mm:ss")}-类别:{state}-错误描述:{exception.Message}");
        }

        protected async override void Log(LogLevel logLevel, Exception exception)
        {
            FileInfo file = null;
            switch (logLevel)
            {
                case LogLevel.Verbose:
                    file = VerboseFile;
                    break;
                case LogLevel.Warning:
                    file = WarningFile;
                    break;
                case LogLevel.Error:
                    file = ErrorFile;
                    break;
            }

            if (file != null)
            {
                var bytes = Encoding.UTF8.GetBytes(Formatter(null, exception));
                using (var fs = file.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    await fs.WriteAsync(bytes, 0, bytes.Length);
                }
            }
        }
    }

    public abstract class DefaultLogger : ILogger
    {
        public abstract IDisposable BeginScopeImpl(object state);

        public virtual bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                case LogLevel.Verbose:
                case LogLevel.Warning:
                    return true;
                default:
                    return false;
            }
        }

        protected abstract void Log(LogLevel logLevel, Exception exception);

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            Log(logLevel, exception);
        }

        public void LogVerbose(string message)
        {
            Log(LogLevel.Verbose, 0, null, new Exception(message), Formatter);
        }

        public void LogWarning(string message)
        {
            Log(LogLevel.Warning, 0, null, new Exception(message), Formatter);
        }

        public void LogError(string message)
        {
            Log(LogLevel.Error, 0, null, new Exception(message), Formatter);
        }

        protected abstract string Formatter(object state, Exception exception);
    }

    public class TextLoggerOption : Microsoft.Extensions.OptionsModel.IOptions<TextLoggerOption>
    {
        public TextLoggerOption Value
        {
            get
            {
                return this;
            }
        }

        public string LoggerPath { get; set; }
    }
}
