using BaseSolution.Utilities.Application;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.Nlog.Configure
{
    public class FileTargetConfigure
    {
        public static FileTarget CreateFileTarget()
        {
            FileTarget fileTarget = new FileTarget("FileRepository")
            {
                FileName = ApplicationSettings.FileLogPath,
                Encoding = Encoding.UTF8,
                Layout = "${message}"
            };

            return fileTarget;
        }
    }
}
