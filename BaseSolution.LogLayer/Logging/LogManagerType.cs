using BaseSolution.LogLayer.Logging.Log4Net.Configure;
using BaseSolution.LogLayer.Logging.Nlog.Configure;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using NLog;
using NLog.Config;

namespace BaseSolution.LogLayer.Logging
{
    public  class LogManagerType
    {
        public LogManagerType()
        {

        }

        #region Log4Net Setup
        /// <summary>
        /// Middleware içinde etkinleştirilmesi gerekiyor
        /// </summary>
        public static void Log4NetSetup()
        {
            var fileAppender = FileAppenderSetup.CreateLog4NetFileAppender();
            var adoAppender = AdoAppenderSetup.CreateLog4NetAdoNetAppender();

            fileAppender.ActivateOptions();
            adoAppender.ActivateOptions();

            string fileRepositoryName = "FileRepository";
            string adoRepositoryName = "DatabaseRepository";

            ILoggerRepository fileRepository = LoggerManager.CreateRepository(fileRepositoryName);
            ILoggerRepository adoRepository = LoggerManager.CreateRepository(adoRepositoryName);

            BasicConfigurator.Configure(fileRepository, fileAppender);
            BasicConfigurator.Configure(adoRepository, adoAppender);

            
        } 
        #endregion


        #region NlogSetup
        /// <summary>
        /// Middleware içinde etkinleştirilmesi gerekiyor
        /// </summary>
        public static void NLogSetup()
        {
            LoggingConfiguration loggingConfiguration = new LoggingConfiguration();

            var fileTarget = FileTargetConfigure.CreateFileTarget();
            var databaseTarget = DatabaseTargetConfigure.CreateDatabaseTarget();

            loggingConfiguration.AddTarget("FileRepository", fileTarget);
            loggingConfiguration.AddTarget("DatabaseRepository", databaseTarget);

            var fileRule = NLogLoggingRule.AddRule("FileLogger", LogLevel.Trace, fileTarget);
            var dbRule = NLogLoggingRule.AddRule("DatabaseLogger", LogLevel.Trace, databaseTarget);

            loggingConfiguration.LoggingRules.Add(fileRule);
            loggingConfiguration.LoggingRules.Add(dbRule);

            LogManager.Configuration = loggingConfiguration;
            LogManager.ReconfigExistingLoggers();

            

            //if databaselog or filelog pls select for event

        } 
        #endregion


    }
}
