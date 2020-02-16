using BaseSolution.Utilities.Application;
using MicroKnights.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.Log4Net.Configure
{
    public class AdoAppenderSetup
    {
        public static AdoNetAppender CreateLog4NetAdoNetAppender()
        {
            AdoNetAppender adoNetAppender = new AdoNetAppender
            {
                ConnectionString = ApplicationSettings.DatabaseLogConnectionString,
                CommandType = System.Data.CommandType.Text,
                BufferSize = 1,
                Name = "DatabaseLogger",
                CommandText = "INSERT INTO dbo.Log (LogDate,Level,Message) VALUES (@LogDate,@Level,@Message)",
                ConnectionType = "System.Data.SqlClient.SqlConnection,System.Data.SqlClient,Version=4.0.0.0,Culture=neutral,PublicKeyToken=b77a5c561934e089"
            };

            Extensions.AddDateTimeParameterToAppender(adoNetAppender, "@LogDate");
            Extensions.AddStringParameterToAppender(adoNetAppender, "@Level", 50, "%level");
            Extensions.AddMessageParameterToAppender(adoNetAppender, System.Data.DbType.String, 4000, "@Message");
            
            return adoNetAppender;
        }
        
    }
}
