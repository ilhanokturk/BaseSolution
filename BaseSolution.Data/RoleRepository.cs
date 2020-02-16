using BaseSolution.Abstraction.Repository.Repositories;
using BaseSolution.Context.Contexts.EntityFramework;
using BaseSolution.Data.Repositories;
using BaseSolution.DTO.DataTransferObjects.User;
using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseSolution.Data
{
    public class RoleRepository : EntityFramewordRepository<Role>, IRoleRepository
    {
        private readonly DbContext _context;
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }

        public List<string> GetRoleByUser(Guid userId)
        {
            var list = new List<string>();

            (from i in _context.Set<Role>()
             join ur in _context.Set<UserRole>()
             on i.Id equals ur.RoleId
             join user in _context.Set<User>() on ur.UserId equals user.Id
             where user.Id == userId
             select new
             {
                 name = i.RoleName
             }).ToList().ForEach(x => list.Add(x.name));

            return list;
        }
    }
}
