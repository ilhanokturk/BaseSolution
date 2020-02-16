using BaseSolution.LogLayer.Logging.LogTypes;
using BaseSolution.MVC.Filter.EventLog;
using BaseSolution.MVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;

namespace BaseSolution.MVC.Controllers
{
    [Route("{culture?}/[controller]/[action]")]
    public class HomeController : BaseController
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IStringLocalizer<HomeController> stringLocalizer)
        {
            _localizer = stringLocalizer;
        }
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult Index() => View();
        public IActionResult Contact() => View();
    }
}