using BaseSolution.Abstraction.Repository.Base;
using BaseSolution.DTO.DataTransferObjects.Category;
using BaseSolution.DTO.Pagination;
using BaseSolution.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSolution.Abstraction.Repository.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<CategorySelectDTO>> GetCategoriesBySearchTerm(string searchTerm);
        IQueryable<Category> GetCategoryListPaging(PaginationAndFilterDataViewModel<CategoryListDTO> viewModel);
    }
}
