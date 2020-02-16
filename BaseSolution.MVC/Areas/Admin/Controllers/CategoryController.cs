using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseSolution.Business.Abstract;
using BaseSolution.DTO.DataTransferObjects.Category;
using BaseSolution.Entity;
using BaseSolution.MVC.Models;
using BaseSolution.MVC.Resources;
using BaseSolution.Utilities.Messages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BaseSolution.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Route("{culture}/Admin/category/[action]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<CategoryController> _localizer;
        private readonly LocalizationService _locService;
        public CategoryController(ICategoryService categoryService, IStringLocalizer<CategoryController> localizer,LocalizationService localizationService)
        {
            _categoryService = categoryService;
            _localizer = localizer;
            _locService = localizationService;

        }

        public IActionResult Index()
        {
            return View();
        }

        //[ActionName("create-category")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme,Roles ="Admin")]
        public IActionResult CreateCategory()
        {
            var name=_localizer["Category Name"];
            return View(new NewCategoryDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ActionName("create-category")]
        public IActionResult CreateCategory(NewCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.CreateNewCategory(model);
                if (result.Success)
                    ViewBag.success = _localizer[nameof(model.CategoryName) +" "+ UIMagicString.Recorded];
            }
            return View(model);
        }

        [HttpGet]
        public async Task<List<CategorySelectDTO>> CategoryList(string searchTerm = "")
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var result = await _categoryService.GetCategorySelectListAsync(searchTerm);
                return result;
            }
            return null;
        }

    }
}