using BaseSolution.LogLayer.Logging.Log4Net.Management;
using BaseSolution.LogLayer.Logging.Nlog.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.LogTypes
{
    public  class DatabaseLogger:NLogManager
    {
        public DatabaseLogger():base("DatabaseLogger")
        {

        }
        
    }
}
