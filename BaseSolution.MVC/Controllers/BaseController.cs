using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseSolution.DTO.DataTransferObjects.User;
using BaseSolution.MVC.Models;
using BaseSolution.Utilities.Messages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BaseSolution.MVC.Controllers
{
    public class BaseController : Controller
    {
        //private readonly IStringLocalizer<BaseController> _localizer;

        public BaseController()//IStringLocalizer<BaseController> localizer)
        {
            //_localizer = localizer;
        }

        protected internal bool IsAuthenticated()
        {
            return HttpContext.User.Identity.IsAuthenticated;
        }

        protected internal string UserEmail()
        {
            if (IsAuthenticated())
                return HttpContext.User.FindFirstValue(ClaimTypes.Email);
            throw new AuthenticationException(UIMagicString.UserNotFound);
        }
        protected internal bool AnyRole()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.Role).Any();
        }
        protected internal string Role()
        {
            if (IsAuthenticated())
                return HttpContext.User.FindFirstValue(ClaimTypes.Role);
            throw new AuthenticationException(UIMagicString.UserNotFound);
        }
        protected internal async Task SignAsync(UserForLogingDTO model, List<string> roles)
        {
            var principal = CreatePrincipal(model, roles);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                AllowRefresh = true
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
        }
        protected internal async Task SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        private ClaimsPrincipal CreatePrincipal(UserForLogingDTO loginModel, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, loginModel.Email));
            string temp = string.Empty;
            roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x)));

            var principal = new ClaimsPrincipal();
            principal.AddIdentity(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            return principal;
        }
    }
}