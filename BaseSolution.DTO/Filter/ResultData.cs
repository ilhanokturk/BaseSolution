using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.Filter
{
    public class ResultData<T> : IFilteredData<T> where T : IDto
    {
        public List<T> Result { get ; set ; }

        public ResultData()
        {
            Result = new List<T>();
        }
    }
}
