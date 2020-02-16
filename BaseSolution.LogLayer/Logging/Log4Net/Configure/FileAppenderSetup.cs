using BaseSolution.LogLayer.Logging.Log4Net.Layouts;
using BaseSolution.Utilities.Application;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.Log4Net.Configure
{
    public class FileAppenderSetup
    {
        public static RollingFileAppender CreateLog4NetFileAppender()
        {
            RollingFileAppender rollingFileAppender = new RollingFileAppender
            {
                File = ApplicationSettings.FileLogPath,
                PreserveLogFileNameExtension = true,
                DatePattern = "-yyyy-MM-dd",
                AppendToFile = true,
                StaticLogFileName = false,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                Name = "FileLogger",
                Encoding = Encoding.UTF8,
                Layout = new JsonLayout(),
            };
            rollingFileAppender.AddFilter(LevelFilter.CreateFilter());
            return rollingFileAppender;
        }
    }
}
