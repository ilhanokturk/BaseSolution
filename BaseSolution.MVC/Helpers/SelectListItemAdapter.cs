using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSolution.MVC.Helpers
{
    public static  class SelectListItemAdapter
    {
        public static IEnumerable<SelectListItem> ConvertToSelectListItemCollection<T>(IEnumerable<T> source,Func<T,string> text,Func<T,string> value,bool createEmpty=true) where T : class
        {
            var selectListItems = new List<SelectListItem>();

            if (createEmpty)
            {
                selectListItems.Add(new SelectListItem { Text = "Please Select", Value = "", Selected = true });
            }

            foreach (var item in source)
            {
                selectListItems.Add(new SelectListItem { Text = text(item), Value = value(item) });
            }

            return selectListItems;
        }
        public static IEnumerable<SelectListItem> ConvertToSelecListItemCollection<T>(IEnumerable<T> source,Func<T,string> textAndValue,bool createEmpty=true) where T:class
        {
            return ConvertToSelectListItemCollection(source, textAndValue, textAndValue, createEmpty);
        }
    }
}
