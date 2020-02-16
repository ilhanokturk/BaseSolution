using log4net.Core;
using log4net.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.LogLayer.Logging.Log4Net.Configure
{
    public class LevelFilter
    {
        public static LevelMatchFilter CreateFilter()
        {
            LevelMatchFilter levelMatchFilter = new LevelMatchFilter();
            levelMatchFilter.LevelToMatch = Level.All;
            levelMatchFilter.ActivateOptions();

            return levelMatchFilter;
        }
    }
}
