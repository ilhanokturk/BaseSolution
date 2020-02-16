using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.MVC.Controllers
{
    public class SettingController : Controller
    {
        private string _currentLanguage;

        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                    return _currentLanguage;

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.Name;
                }

                return _currentLanguage;
            }
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            

            return LocalRedirect(GetReturnUrl(culture,returnUrl));
        }

        public ActionResult RedirectToDefaultLanguage()
        {
            var culture = CurrentLanguage;
            if (culture != "tr-TR" && culture != "en-US")
                throw new Exception("culture error");

            var path=HttpContext.Request.Path;
            if(!path.Value.Contains("tr-TR") && !path.Value.Contains("en-US"))
            {
                var returnUrl = "/" + culture + path;
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index","Home", new { culture });
        }

    
        

        [NonAction]
        private string GetReturnUrl(string culture,string returnUrl)
        {
            if (culture == "tr-TR")
            {
                if (returnUrl.Contains("en-US"))
                {
                    returnUrl = returnUrl.Replace("en-US", "tr-TR");
                }
            }
            else if (culture == "en-US")
            {
                if (returnUrl.Contains("tr-TR"))
                    returnUrl = returnUrl.Replace("tr-TR", "en-US");
            }
            else
            {
                throw new Exception("Hata");
            }
            return returnUrl;
        }
    }
}