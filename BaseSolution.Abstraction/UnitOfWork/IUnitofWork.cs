using BaseSolution.Abstraction.Repository.Base;
using BaseSolution.Abstraction.Repository.Repositories;

namespace BaseSolution.Abstraction.UnitOfWork
{
    public interface IUnitofWork<T> where T:class
    {
        IRepository<T> Repository { get; }
        ISP_Call SP_Call { get; }

        ICategoryRepository CategoryRepository { get; }
        
        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }

        int SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
