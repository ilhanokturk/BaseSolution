using BaseSolution.DTO.Filter;
using BaseSolution.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.DataTransferObjects.Category
{
    public class PaginationAndFilterDataViewModel<T> where T:IDto
    {
        public PaginationAndFilterDataViewModel()
        {
            Filters = new FilterDTO();
            Pagination = new PaginationItem();
            Data = new ResultData<T>();
        }
        public ResultData<T> Data { get; set; }
        public FilterDTO Filters { get; set; }
        public PaginationItem Pagination { get; set; }
    }
}
