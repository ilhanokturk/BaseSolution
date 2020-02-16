using BaseSolution.Utilities.Enums;

namespace BaseSolution.Abstraction.Logging
{
    public abstract class ILoggerBase
    {
        public abstract void Write(ApplicationLogType logType, object message);
        protected abstract void LogInfo(string message);
        protected abstract void LogError(string message);
        protected abstract void LogWarn(string message);
        protected abstract void LogDebug(string message);
        protected abstract void LogFatal(string message);

    }
}
