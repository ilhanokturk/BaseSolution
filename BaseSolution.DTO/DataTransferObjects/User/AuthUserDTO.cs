using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.DataTransferObjects.User
{
    public class AuthUserDTO
    {
        
        public List<string> Roles { get; set; }

        public AuthUserDTO()
        {
            Roles = new List<string>();
        }
    }
}
