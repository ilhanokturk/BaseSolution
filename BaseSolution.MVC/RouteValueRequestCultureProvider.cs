﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSolution.MVC
{
    internal class RouteValueRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            string cultureCode = null;

            if (httpContext.Request.Path.HasValue && httpContext.Request.Path.Value == "/")
                cultureCode = this.GetDefaultCultureCode();

            // TODO: make it look more beautiful
            else if (httpContext.Request.Path.HasValue && httpContext.Request.Path.Value.Length >= 4 && httpContext.Request.Path.Value[0] == '/' && httpContext.Request.Path.Value[3] == '/')
            {
                cultureCode = httpContext.Request.Path.Value.Substring(1, 2);

                if (!this.CheckCultureCode(cultureCode))
                    cultureCode = this.GetDefaultCultureCode(); //throw new HttpException(HttpStatusCode.NotFound);
            }

            else cultureCode = this.GetDefaultCultureCode(); //throw new HttpException(HttpStatusCode.NotFound);

            // TODO: from the SEO point of view, we should return 404 error code for unknown cultures

            ProviderCultureResult requestCulture = new ProviderCultureResult(cultureCode);

            return Task.FromResult(requestCulture);
        }

        private string GetDefaultCultureCode()
        {
            return this.Options.DefaultRequestCulture.Culture.Name;
        }

        private bool CheckCultureCode(string cultureCode)
        {
            return this.Options.SupportedCultures.Select(c => c.Name).Contains(cultureCode);
        }
    }
}