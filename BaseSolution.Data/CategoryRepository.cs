using BaseSolution.Abstraction.Repository.Repositories;
using BaseSolution.Context.Contexts.EntityFramework;
using BaseSolution.Data.Repositories;
using BaseSolution.DTO.DataTransferObjects.Category;
using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BaseSolution.Utilities.Extensions;
using BaseSolution.DTO.Pagination;

namespace BaseSolution.Data
{
    public class CategoryRepository: EntityFramewordRepository<Category>, ICategoryRepository
    {
        private readonly DbContext _context;
        public CategoryRepository(DbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<List<CategorySelectDTO>> GetCategoriesBySearchTerm(string searchTerm)
        {
            var query = await (from Category v in _context.Set<Category>()
                               where v.Name.ToLower().Contains(searchTerm.ToLower())
                               select new CategorySelectDTO()
                               {
                                   id = v.Id.ToString(),
                                   text = v.Name
                               }).ToListAsync();

            return query;
        }

        public IQueryable<Category> GetCategoryListPaging(PaginationAndFilterDataViewModel<CategoryListDTO> viewModel)
        {
            var query = _context.Set<Category>().AsQueryable();
            return query;
        }

       
    }
}
