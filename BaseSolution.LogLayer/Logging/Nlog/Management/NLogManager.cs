using BaseSolution.Abstraction.Logging;
using BaseSolution.Utilities.Enums;
using Newtonsoft.Json;
using NLog;
using System;

namespace BaseSolution.LogLayer.Logging.Nlog.Management
{
    public class NLogManager : Abstraction.Logging.ILoggerBase, ILoggerManager
    {
        private readonly NLog.ILogger _logger;
        public NLogManager(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);

        }

        private bool IsInfoEnabled => _logger.IsInfoEnabled;
        private bool IsDebugEnabled => _logger.IsDebugEnabled;
        private bool IsWarnEnabled => _logger.IsWarnEnabled;
        private bool IsFatalEnabled => _logger.IsFatalEnabled;
        private bool IsErrorEnabled => _logger.IsErrorEnabled;

        protected override void LogDebug(string message)
        {
            if (IsDebugEnabled)
            {
                var theEvent = new LogEventInfo(LogLevel.Debug, _logger.Name, message);
                if (_logger.Name == "DatabaseLogger")
                    _logger.Log(theEvent);
                else
                {
                    var newEventMessage = "{ Message: " + theEvent.Message + " },";
                    theEvent.Message = newEventMessage;
                    _logger.Log(theEvent);
                }
            }

        }

        protected override void LogError(string message)
        {
            if (IsErrorEnabled)
            {
                var theEvent = new LogEventInfo(LogLevel.Error, _logger.Name, message);
                if (_logger.Name == "DatabaseLogger")
                    _logger.Log(theEvent);
                else
                {
                    var newEventMessage = "{ Message:" + theEvent.Message + " },";
                    theEvent.Message = newEventMessage;
                    _logger.Log(theEvent);
                }
            }

        }

        protected override void LogFatal(string message)
        {
            var theEvent = new LogEventInfo(LogLevel.Fatal, _logger.Name, message);
            if (IsFatalEnabled)
            {
                if (_logger.Name == "DatabaseLogger")
                    _logger.Log(theEvent);
                else
                {
                    var newEventMessage = "{ Message:" + theEvent.Message + " },";
                    theEvent.Message = newEventMessage;
                    _logger.Log(theEvent);
                }

            }

        }

        protected override void LogInfo(string message)
        {
            if (IsInfoEnabled)
            {
                var theEvent = new LogEventInfo(LogLevel.Info, _logger.Name, message);
                if (_logger.Name == /*NlogEventRepositoryType.DatabaseRepository.DescriptionAttr()*/"DatabaseLogger")
                {
                    _logger.Log(theEvent);
                }
                else
                {
                    var newEventMessage = "{ Message:" + theEvent.Message + " },";
                    theEvent.Message = newEventMessage;
                    _logger.Log(theEvent);
                }
            }
        }

        protected override void LogWarn(string message)
        {
            if (IsWarnEnabled)
            {
                var theEvent = new LogEventInfo(LogLevel.Warn, _logger.Name, (string)message);
                if (_logger.Name == "DatabaseLogger")
                    _logger.Log(theEvent);
                else
                {
                    var newEventMessage = "{ Message:" + theEvent.Message + " },";
                    theEvent.Message = newEventMessage;
                    _logger.Log(theEvent);
                }
            }

        }

        public override void Write(ApplicationLogType logType, object message)
        {
            var serilazedLog = JsonConvert.SerializeObject(message, Formatting.Indented);
            switch (logType)
            {
                case ApplicationLogType.Debug:
                    LogDebug(serilazedLog);
                    break;
                case ApplicationLogType.Info:
                    LogInfo(serilazedLog);
                    break;
                case ApplicationLogType.Warn:
                    LogWarn(serilazedLog);
                    break;
                case ApplicationLogType.Error:
                    LogError(serilazedLog);
                    break;
                case ApplicationLogType.Fatal:
                    LogFatal(serilazedLog);
                    break;
                default:
                    throw new Exception("LogType cannot be null");
            }
        }

       
    }
}
