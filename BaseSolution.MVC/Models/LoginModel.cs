﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSolution.MVC.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Email is not empty.")]
        //[EmailAddress(ErrorMessage = "Wrong email format.")]
        [Display(Name = "Your email")]
        //[StringLength(50,ErrorMessage = "Email should not exceed 50 characters")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is not empty")]
        [Display(Name = "Your password")]
        //[DataType(DataType.Password)]
        //[StringLength(20,ErrorMessage = "Password should not exceed 20 characters")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
