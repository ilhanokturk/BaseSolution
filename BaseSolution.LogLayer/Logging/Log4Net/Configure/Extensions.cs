using BaseSolution.LogLayer.Logging.Log4Net.Layouts;
using log4net.Layout;
using MicroKnights.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BaseSolution.LogLayer.Logging.Log4Net.Configure
{
    public static class Extensions
    {
        public static void AddMessageParameterToAppender(this AdoNetAppender appender,DbType dbType,int size,string parameterName)
        {
            var param = new AdoNetAppenderParameter
            {
                ParameterName = parameterName,
                DbType = DbType.String,
                Size = size,
                Layout = new JsonLayout()
            };
            appender.AddParameter(param);
        }
        public static void AddStringParameterToAppender(this AdoNetAppender appender, string paramName, int size, string conversionPattern)
        {
            var param = new AdoNetAppenderParameter
            {
                ParameterName = paramName,
                DbType = System.Data.DbType.String,
                Size = size,
                Layout = new Layout2RawLayoutAdapter(new PatternLayout(conversionPattern))
            };
            appender.AddParameter(param);
        }
        public static void AddDateTimeParameterToAppender(this AdoNetAppender appender, string paramName)
        {
            var param = new AdoNetAppenderParameter
            {
                ParameterName = paramName,
                DbType = System.Data.DbType.String,
                Size=50,
                Layout = new RawTimeStampLayout()
            };
            appender.AddParameter(param);
        }
        public static void AddErrorParameterToAppender(this AdoNetAppender appender, string paramName, int size)
        {
            var param = new AdoNetAppenderParameter
            {
                ParameterName = paramName,
                DbType = System.Data.DbType.String,
                Size = size,
                Layout = new Layout2RawLayoutAdapter(new ExceptionLayout())
            };
            appender.AddParameter(param);
        }
    }
}
