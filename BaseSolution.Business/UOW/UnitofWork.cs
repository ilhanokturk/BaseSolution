using BaseSolution.Abstraction.Repository.Base;
using BaseSolution.Abstraction.Repository.Repositories;
using BaseSolution.Abstraction.UnitOfWork;
using BaseSolution.Context.Contexts.EntityFramework;
using BaseSolution.Data;
using BaseSolution.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Business.UOW
{
    public class UnitofWork<T>: IUnitofWork<T> where T:class
    {
        private ApplicationContext _context;
        IRepository<T> _repo;
        private ICategoryRepository _categoryRepo;
        private IUserRepository _userRepo;
        private IRoleRepository _roleRepo;

        public UnitofWork(ApplicationContext application)
        {
            _context = application;
        }

        public IRepository<T> Repository 
        {
            get
            {
                return new EntityFramewordRepository<T>(_context);
            }
        }

        public ISP_Call SP_Call => throw new NotImplementedException();

        public ICategoryRepository CategoryRepository => _categoryRepo ?? (_categoryRepo = new CategoryRepository(_context));

        public IUserRepository UserRepository => _userRepo ?? (_userRepo = new UserRepository(_context));

        public IRoleRepository RoleRepository => _roleRepo ?? (_roleRepo = new RoleRepository(_context));

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
