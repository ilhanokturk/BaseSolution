using BaseSolution.Abstraction.Repository.Repositories;
using BaseSolution.Context.Contexts.EntityFramework;
using BaseSolution.Data.Repositories;
using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;

namespace BaseSolution.Data
{
    public class UserRepository:EntityFramewordRepository<User>,IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext dbContext):base(dbContext)
        {
            this._context = dbContext;
        }
    }
}
