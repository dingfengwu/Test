/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：TxtLoggerProvider.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：WDF
// 创建日期：2016-04-12 11:01:39
//----------------------------------------------------------------*/



using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;

namespace Kehu1688.Framework.Base
{
    public class TextLoggerProvider : ILoggerProvider
    {
        TextLoggerOption _options;
        public TextLoggerProvider(TextLoggerOption options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(options.LoggerPath))
                throw new ArgumentNullException(nameof(options), Resource.ResourceManager.GetString("ERROR_PATH_NOT_FOUND"));
            
            _options = options;
        }
        public TextLoggerProvider(Action<TextLoggerOption> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _options = new TextLoggerOption();
            options(_options);

            if (string.IsNullOrWhiteSpace(_options.LoggerPath))
                throw new ArgumentNullException(nameof(options), Resource.ResourceManager.GetString("ERROR_PATH_NOT_FOUND"));
        }

        public ILogger CreateLogger(string categoryName)
        {
            _options.LoggerCategory = categoryName;
            return new TextLogger(_options);
        }

        public void Dispose()
        {
            
        }
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
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(options.LoggerPath))
                throw new ArgumentNullException(nameof(options), Resource.ResourceManager.GetString("ERROR_PATH_NOT_FOUND"));

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
                        _warningFile = new FileInfo(LogFilename(LogLevel.Warning));
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
                        _errorFile = new FileInfo(LogFilename(LogLevel.Error));
                }
                return _errorFile;
            }
        }

        public string LogFilename(LogLevel logLevel)
        {
            return Path.Combine(_options.LoggerPath, $"{logLevel.ToString()}{DateTime.Now.ToString("yyyyMMdd")}.log");
        }
        
        protected override string Formatter(object state, Exception exception)
        {
            if (state == null && exception == null) { return string.Empty; }

            if (exception == null)
            {
                return $"时间:{DateTime.Now.ToString("HH:mm:ss")}-类别:{_options.LoggerCategory}-状态：{state.ToString()}\r\n\r\n";
            }
            else
            {
                return $"时间:{DateTime.Now.ToString("HH:mm:ss")}-类别:{_options.LoggerCategory}-状态：{state.ToString()}-错误描述:{exception.Message}\r\n\r\n";
            }
        }

        protected async override void Log(LogLevel logLevel,object state, Exception exception)
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

            try
            {
                if (file != null)
                {
                    var bytes = Encoding.UTF8.GetBytes(Formatter(state, exception));
                    using (var fs = file.Open(FileMode.Append, FileAccess.Write, FileShare.Write))
                    {
                        await fs.WriteAsync(bytes, 0, bytes.Length);
                        fs.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }

    public abstract class DefaultLogger : ILogger
    {
        public virtual IDisposable BeginScopeImpl(object state)
        {
            return NoopDisposable.Instance;
        }

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

        protected abstract void Log(LogLevel logLevel,object state, Exception exception);

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            Log(logLevel,state, exception);
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
        
        private class NoopDisposable : IDisposable
        {
            public static NoopDisposable Instance = new NoopDisposable();

            public void Dispose()
            {

            }
        }
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

        /// <summary>
        /// 日志文件路径
        /// </summary>
        public string LoggerPath { get; set; }

        /// <summary>
        /// 日志文件类别
        /// </summary>
        public string LoggerCategory { get; set; }
    }
}
