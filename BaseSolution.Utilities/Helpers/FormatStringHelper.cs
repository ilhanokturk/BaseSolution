using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Utilities.Helpers
{
    public static class FormatStringHelper
    {
        public static string StringFormat(this string text,string text1)
        {
            return $"{text} {text1}";
        }
    }
}
