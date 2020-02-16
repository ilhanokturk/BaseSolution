using BaseSolution.Abstraction.Results;
using BaseSolution.DTO.DataTransferObjects.Category;
using BaseSolution.DTO.Pagination;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Business.Abstract
{
    public interface ICategoryService
    {
        IResult CreateNewCategory(NewCategoryDTO model);
        //Task<IEnumerable<SelectListItem>> GetCategoryList();
        Task<List<CategorySelectDTO>> GetCategorySelectListAsync(string searchTerm);

        PaginationAndFilterDataViewModel<CategoryListDTO> GetCategoryListWithPaging(PaginationAndFilterDataViewModel<CategoryListDTO> viewModel);
    }
}
