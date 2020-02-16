using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.LogObjects
{
    public class LogDetail
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string CurrentUser { get; set; }
        public List<LogParameter> LogParameters { get; set; }
        public string ReturnType { get; set; }
    }
}
