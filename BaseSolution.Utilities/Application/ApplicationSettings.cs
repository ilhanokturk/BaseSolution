using BaseSolution.Utilities.Enums;

namespace BaseSolution.Utilities.Application
{
    public static class ApplicationSettings
    {
        public static string MssqlConnectionString { get; set; }
        public static string DatabaseLogConnectionString { get; set; }
        public static string FileLogPath { get; set; }
        public static string LogRepository { get; set; }
        public static NlogEventRepositoryType NlogEventRepositoryType { get; set; }
        public static Log4NetEventLoggerType Log4NetEventLoggerType { get; set; }
    }
}
