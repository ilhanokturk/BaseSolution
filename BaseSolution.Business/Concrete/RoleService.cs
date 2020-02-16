using BaseSolution.Abstraction.UnitOfWork;
using BaseSolution.Business.Abstract;
using BaseSolution.DTO.DataTransferObjects.User;
using BaseSolution.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Business.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork<Role> _uow;

        public RoleService(IUnitofWork<Role> uow)
        {
            _uow = uow;
        }
    }
}
