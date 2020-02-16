using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseSolution.Business.Abstract;
using BaseSolution.DTO.DataTransferObjects.User;
using BaseSolution.MVC.Models;
using BaseSolution.MVC.Resources;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BaseSolution.MVC.Controllers
{
    [Route("{culture?}/[controller]/[action]")]
    public class AuthController : BaseController
    {
        private readonly IStringLocalizer<AuthController> _localizer;
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;
        private readonly ILocalization _localization;
        public AuthController(IStringLocalizer<AuthController> localizer,IAuthService authService,IRoleService roleService,ILocalization localization)
        {
            _localizer = localizer;
            _authService = authService;
            _roleService = roleService;
            _localization = localization;
        }

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl=null)
        {
            //string[] dizi = new string[] { "Example1", "Example2" };
            //var asd=_localization.GetLocalizedString("{0} {1} is not valid", dizi);

            return View(new UserForLogingDTO() { ReturnUrl=ReturnUrl});
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserForLogingDTO model)
        {
            string culture;
            if(HttpContext.Request.Cookies.TryGetValue(".AspNetCore.Culture", out culture))
            {
                var _returnUrl = model.ReturnUrl ?? Url.Content("~/");
                if (ModelState.IsValid)
                {
                    var userToLogin = _authService.Login(model);
                    if (!userToLogin.Success)
                    {
                        ViewBag.Error = _localizer[userToLogin.Message];
                        return View(model);
                    }
                    else
                    {
                        await this.SignAsync(model, userToLogin.Data.Roles);
                        return LocalRedirect(_returnUrl);
                    }
                }
            }

           
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}