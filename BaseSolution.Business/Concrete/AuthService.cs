using BaseSolution.Abstraction.Results;
using BaseSolution.Abstraction.UnitOfWork;
using BaseSolution.Business.Abstract;
using BaseSolution.Core.Results.ObjectPattern;
using BaseSolution.Core.Security;
using BaseSolution.DTO.DataTransferObjects.User;
using BaseSolution.Entity;
using BaseSolution.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUnitofWork<User> _uow;

        public AuthService(IUnitofWork<User> uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// kullanıcı girişi kontrol
        /// </summary>
        /// <param name="userForLogingDTO"></param>
        /// <returns></returns>
        public IDataResult<AuthUserDTO> Login(UserForLogingDTO userForLogingDTO)
        {
            var checkUser = _uow.UserRepository.GetBy(x => x.Email.ToLower() == userForLogingDTO.Email.ToLower());
            if (checkUser == null)
                return new ErrorDataResult<UserForLogingDTO>(UIMagicString.EmailNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForLogingDTO.Password, checkUser.PasswordHash, checkUser.PasswordSalt))
                return new ErrorDataResult<UserForLogingDTO>(UIMagicString.PasswordError);

            var result=_uow.RoleRepository.GetRoleByUser(checkUser.Id);

            var model = new UserForLogingDTO
            {
                Roles = result,
                Email=userForLogingDTO.Email,
                Password=userForLogingDTO.Password,
                ReturnUrl=userForLogingDTO.ReturnUrl
            };

            return new SuccessDataResult<UserForLogingDTO>(model, UIMagicString.SuccessfulLogin);
        }

        public IDataResult<UserForRegisterDTO> Register(UserForRegisterDTO userForRegisterDTO, string password)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
