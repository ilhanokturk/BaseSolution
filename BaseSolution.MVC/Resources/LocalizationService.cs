using BaseSolution.MVC.Resources;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BaseSolution.MVC.Resources
{
    public class LocalizationService : ILocalization
    {
        private readonly IStringLocalizer _localizer;
        private readonly IHtmlLocalizer _htmlLocalizer;

        public LocalizationService(IHtmlLocalizerFactory htmlLocalizer,IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResources);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResources", assemblyName.Name);
            _htmlLocalizer = htmlLocalizer.Create(type.Name, assemblyName.Name);
        }
        public LocalizedString GetLocalizedHtmlString(string key) => _localizer[key];

        public string GetLocalizedString(string key,params string[] args)
        {
            var sw = new StringWriter();

            if (args == null)
                _htmlLocalizer[key].WriteTo(sw, HtmlEncoder.Default);
            else
                _htmlLocalizer[key, args].WriteTo(sw, HtmlEncoder.Default);

            return sw.ToString();
        }
       
    }
}
