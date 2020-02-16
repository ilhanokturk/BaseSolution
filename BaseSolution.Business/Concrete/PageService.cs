using BaseSolution.Abstraction.UnitOfWork;
using BaseSolution.Business.Abstract;
using BaseSolution.Entity;
using BaseSolution.Entity.Base;

namespace BaseSolution.Business.Concrete
{
    public class PageService<T>:IPageService<T> where T:BaseEntity
    {
        private readonly IUnitofWork<T> _uow;

        public PageService(IUnitofWork<T> uow)
        {
            _uow = uow;
        }
      
    }
}
