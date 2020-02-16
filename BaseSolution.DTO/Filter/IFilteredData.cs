using BaseSolution.DTO.DataTransferObjects.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.Filter
{
    public interface IFilteredData<T> where T:IDto
    {
        List<T> Result { get; set; }

      
    }
}
