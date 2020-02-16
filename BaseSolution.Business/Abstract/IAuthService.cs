using BaseSolution.Abstraction.Results;
using System;
using System.Collections.Generic;
using System.Text;
using BaseSolution.DTO.DataTransferObjects.User;

namespace BaseSolution.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<AuthUserDTO> Login(UserForLogingDTO userForLogingDTO);
        IDataResult<UserForRegisterDTO> Register(UserForRegisterDTO userForRegisterDTO, string password);
        IResult UserExists(string email);
    }
}
