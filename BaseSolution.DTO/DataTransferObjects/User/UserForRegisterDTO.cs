using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.DataTransferObjects.User
{
    public class UserForRegisterDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
    }
}
