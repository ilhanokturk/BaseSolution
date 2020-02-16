using BaseSolution.Abstraction.UnitOfWork;
using BaseSolution.Business.Abstract;
using BaseSolution.DTO.DataTransferObjects.Category;
using BaseSolution.Entity;
using BaseSolution.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using BaseSolution.Abstraction.Results;
using BaseSolution.Core.Results.ObjectPattern;
using BaseSolution.Utilities.Messages;
using BaseSolution.Utilities.Helpers;
using BaseSolution.Core.Aspects.AutoFac.Logging;
using BaseSolution.LogLayer.Logging.LogTypes;
using BaseSolution.DTO.Pagination;
using BaseSolution.DTO;
using BaseSolution.DTO.Filter;

namespace BaseSolution.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private IUnitofWork<Category> _uow;

        public CategoryService(IUnitofWork<Category> unitofWork)
        {
            _uow = unitofWork;
        }

        [LogAspect(typeof(FileLogger))]
        public IResult CreateNewCategory(NewCategoryDTO model)
        {
            try
            {
                _uow.BeginTransaction();
                var entity = new Category
                {
                    Name = model.CategoryName,
                    Slug = model.CategoryName.ToUrlSlug(),
                    ParentId = model.ParentCategoryId ?? null
                };

                _uow.Repository.Create(entity);
                _uow.SaveChanges();
                _uow.Commit();
                //return new SuccessResult(nameof(entity.Name).StringFormat(UIMagicString.Created));
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                throw new TransactionException(UIMagicString.CreatedError);
            }
            

        }

        public PaginationAndFilterDataViewModel<CategoryListDTO> GetCategoryListWithPaging(PaginationAndFilterDataViewModel<CategoryListDTO> viewModel)
        {
           
            var query = _uow.CategoryRepository.GetCategoryListPaging(viewModel);

            if (viewModel.Filters != null)
            {
                if (viewModel.Filters.Filter != null)
                {
                    if (viewModel.Filters.Filter.Count > 0)
                    {
                        if (viewModel.Filters.Filter.Where(x => x.Name == "CategoryName") != null)
                        {
                            var q = viewModel.Filters.Filter.Where(x => x.Name == "CategoryName").FirstOrDefault().Value;
                            query = query.Where(x => x.Name == q);
                        }
                    }
                }
               
                if (!string.IsNullOrEmpty(viewModel.Filters.MaxDate))
                {
                    var date = Convert.ToDateTime(viewModel.Filters.MaxDate);
                    query = query.Where(x => x.CreateDate < date);
                }
                if (!string.IsNullOrEmpty(viewModel.Filters.MinDate))
                {
                    var date = Convert.ToDateTime(viewModel.Filters.MinDate);
                    query = query.Where(x => x.CreateDate > date);
                }

                //sıralama yapılcak
            }


            int rowCount = query.Count();
            int pageCount = (int)Math.Ceiling((double)(rowCount / viewModel.Pagination.PageSize));
            viewModel.Pagination.CurrentPage = viewModel.Pagination.CurrentPage;
            viewModel.Pagination.PageSize = viewModel.Pagination.PageSize;
            viewModel.Pagination.RowCount = rowCount;
            viewModel.Pagination.PageCount = pageCount;

            var skip = (viewModel.Pagination.CurrentPage - 1) * viewModel.Pagination.PageSize;

           

           var data = query.Skip(skip).Take(viewModel.Pagination.PageSize).ToList();

          

           viewModel.Data.Result = data.Select(x => new CategoryListDTO()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return viewModel;

        }





        //public async Task<IEnumerable<SelectListItem>> GetCategoryList()
        //{
        //    var categories = await _uow.CategoryRepository.GetByListAsync();
        //    var selectListItemList=categories.ToSelectListItem();
        //    return selectListItemList;
        //}

        public async Task<List<CategorySelectDTO>> GetCategorySelectListAsync(string searchTerm)
         {
            var query =await _uow.CategoryRepository.GetCategoriesBySearchTerm(searchTerm);
            return query;
        }

   
    }
}
