using BaseSolution.DTO.DataTransferObjects.Category;
using BaseSolution.MVC.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSolution.MVC.Validators.Users
{
    public class CreateCategoryValidator:AbstractValidator<NewCategoryDTO>
    {
        private ILocalization _localizer;
        public CreateCategoryValidator(ILocalization localizer)
        {
            _localizer = localizer;

            RuleFor(x => x.CategoryName).NotNull().WithMessage(x => _localizer.GetLocalizedHtmlString("Required"));
        }
    }
}
