using BaseSolution.LogLayer.Logging.Nlog.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.LogTypes
{
    public class FileLogger:NLogManager
    {
        public FileLogger():base("FileLogger")
        {

        }
    }
}
