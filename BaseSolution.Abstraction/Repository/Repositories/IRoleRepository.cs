using BaseSolution.Abstraction.Repository.Base;
using BaseSolution.DTO.DataTransferObjects.User;
using BaseSolution.Entity;
using System;
using System.Collections.Generic;

namespace BaseSolution.Abstraction.Repository.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// Roles by user
        /// </summary>
        /// <param name="checkUser"></param>
        /// <returns></returns>
        List<string> GetRoleByUser(Guid userId);
    }
}
