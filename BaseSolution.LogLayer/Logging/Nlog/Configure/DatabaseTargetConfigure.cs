using BaseSolution.Utilities.Application;
using NLog.Targets;

namespace BaseSolution.LogLayer.Logging.Nlog.Configure
{
    public class DatabaseTargetConfigure
    {
        /// <summary>
        /// Create DatabaseTarget schema for NLog
        /// </summary>
        /// <returns>DatabaseTarget object</returns>
        public static DatabaseTarget CreateDatabaseTarget()
        {
            DatabaseTarget databaseTarget = new DatabaseTarget("DatabaseRepository")
            {
                ConnectionString = ApplicationSettings.DatabaseLogConnectionString,
                CommandText = "insert into dbo.Log (LogDate,Level,Message) VALUES (@LogDate, @Level, @Message)",
                CommandType = System.Data.CommandType.Text
            };
            Extensions.AddParameterToDatabaseTarget(databaseTarget, "@LogDate", "${date:format=dd.MM.yyyy HH\\:mm\\:ss");
            Extensions.AddParameterToDatabaseTarget(databaseTarget, "@Level", "${level:uppercase=true}");
            Extensions.AddParameterToDatabaseTarget(databaseTarget, "@Message", "${message}");
            
            return databaseTarget;
        }
    }
    //format=yyyy/MM/dd HH\\:mm\\:ss.fff}
}
