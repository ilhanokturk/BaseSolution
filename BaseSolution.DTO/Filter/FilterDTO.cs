using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.Filter
{
    public class FilterDTO
    {
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
        public List<NameValuePair> Filter { get; set; }
        public ColumnOrder Order { get; set; }

    }
}
