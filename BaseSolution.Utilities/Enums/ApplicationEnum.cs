using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaseSolution.Utilities.Enums
{
    public enum ApplicationLogType
    {
        Debug,
        Info, 
        Warn,
        Error,
        Fatal
    }
    public enum NlogEventRepositoryType
    {
        [Description("DatabaseRepository")]
        DatabaseRepository,
        [Description("FileRepository")]
        FileRepository
    }
    public enum Log4NetEventLoggerType
    {
        [Description("DatabaseLogger")]
        DatabaseLogger,
        [Description("FileLogger")]
        FileLogger
    }
    public enum Log4NetRepositoryType
    {
        [Description("DatabaseRepository")]
        DatabaseRepository,
        [Description("FileRepository")]
        FileRepository
    }
}
