using BaseSolution.Abstraction.Logging;
using BaseSolution.Utilities.Enums;
using log4net;

namespace BaseSolution.LogLayer.Logging.Log4Net.Management
{
    public class Log4NetManager : ILoggerBase, ILoggerManager
    {
        private readonly ILog _log;

        public Log4NetManager(string name)
        {
            if (name == "FileLogger")
                _log = LogManager.GetLogger("FileRepository", name);
            else
                _log = LogManager.GetLogger("DatabaseRepository", name);
        }

        private bool IsInfoEnabled => _log.IsInfoEnabled;
        private bool IsDebugEnabled => _log.IsDebugEnabled;
        private bool IsWarnEnabled => _log.IsWarnEnabled;
        private bool IsFatalEnabled => _log.IsFatalEnabled;
        private bool IsErrorEnabled => _log.IsErrorEnabled;

        public override void Write(ApplicationLogType logType, object message)
        {
            switch (logType)
            {
                case ApplicationLogType.Debug:
                    LogDebug((string)message);
                    break;
                case ApplicationLogType.Info:
                    LogInfo((string)message);
                    break;
                case ApplicationLogType.Warn:
                    LogWarn((string)message);
                    break;
                case ApplicationLogType.Error:
                    LogError((string)message);
                    break;
                case ApplicationLogType.Fatal:
                    LogFatal((string)message);
                    break;
                default:
                    break;
            }
        }

        protected override void LogDebug(string message)
        {
            if (IsDebugEnabled)
                _log.Debug(message);
        }

        protected override void LogError(string message)
        {
            if (IsErrorEnabled)
                _log.Error(message);
        }

        protected override void LogFatal(string message)
        {
            if (IsFatalEnabled)
                _log.Fatal(message);
        }

        protected override void LogInfo(string message)
        {
            if (IsInfoEnabled)
                _log.Info(message);
        }

        protected override void LogWarn(string message)
        {
            if (IsWarnEnabled)
                _log.Warn(message);
        }





        //public void Debug(object logMessage)
        //{
        //    if (IsDebugEnabled)
        //        _log.Debug(logMessage);
        //}

        //public void Warn(object logMessage)
        //{
        //    if (IsWarnEnabled)
        //        _log.Warn(logMessage);
        //}

        //public void Fatal(object logMessage)
        //{
        //    if (IsFatalEnabled)
        //        _log.Fatal(logMessage);
        //}

        //public void Error(object logMessage)
        //{
        //    if (IsErrorEnabled)
        //        _log.Error(logMessage);
        //}
    }
}
