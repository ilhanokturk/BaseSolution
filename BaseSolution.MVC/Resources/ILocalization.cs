using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSolution.MVC.Resources
{
    public interface ILocalization
    {
        LocalizedString GetLocalizedHtmlString(string key);
        string GetLocalizedString(string key, params string[] args);
    }
}
