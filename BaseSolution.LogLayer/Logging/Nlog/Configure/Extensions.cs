using NLog.Layouts;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.Nlog.Configure
{
    public static class Extensions
    {
        /// <summary>
        /// Adding to parameter to Nlog databasetarget object
        /// </summary>
        /// <param name="databaseTarget">extended object</param>
        /// <param name="parameterName">parametername</param>
        /// <param name="parameterLayout">Layout type</param>
        public static void AddParameterToDatabaseTarget(this DatabaseTarget databaseTarget,string parameterName,Layout parameterLayout)
        {
            var param = new DatabaseParameterInfo(parameterName, parameterLayout);
            databaseTarget.Parameters.Add(param);
        }

        //internal static void AddDatetimeParameterDatabaseTarget(this DatabaseTarget databaseTarget, string v1, string v2)
        //{
        //    var 
        //}
    }
}
