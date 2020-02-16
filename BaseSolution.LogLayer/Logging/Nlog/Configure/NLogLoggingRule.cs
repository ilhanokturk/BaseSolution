using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.Nlog.Configure
{
    public class NLogLoggingRule
    {
        /// <summary>
        /// Adding rule
        /// </summary>
        /// <param name="loggerType"></param>
        /// <param name="logLevel">Nlog Level</param>
        /// <param name="target">Nlog Target</param>
        /// <returns>LoggingRule object</returns>
        public static LoggingRule AddRule(string loggerType,LogLevel logLevel,Target target)
        {
            LoggingRule loggingRule = new LoggingRule(loggerType, logLevel, target);
            return loggingRule;
        }
    }
}
