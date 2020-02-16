using BaseSolution.DTO.DataTransferObjects.User;
using BaseSolution.MVC.Models;
using BaseSolution.MVC.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSolution.MVC.Validators.Users
{
    public class LoginModelValidator:AbstractValidator<UserForLogingDTO>
    {
        private ILocalization _localizer;
        public LoginModelValidator(ILocalization localizer)
        {
        _localizer = localizer;
            RuleFor(x => x.Email).NotNull().WithMessage(x => _localizer.GetLocalizedHtmlString("Required"));
            RuleFor(x => x.Email).EmailAddress(mode: FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage(x => _localizer.GetLocalizedHtmlString("Wrong email format"));
            RuleFor(x => x.Email).MaximumLength(50).WithMessage(_localizer.GetLocalizedHtmlString("Email should not exceed 50 characters"));
            RuleFor(x => x.Password).NotNull().WithMessage(_localizer.GetLocalizedHtmlString("Password is not empty"));
            RuleFor(x => x.Password).MaximumLength(20).WithMessage(_localizer.GetLocalizedHtmlString("Password should not exceed 20 characters"));
        }
    }
}
