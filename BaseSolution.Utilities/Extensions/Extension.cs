using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BaseSolution.Utilities.Extensions
{
    public static class Extension
    {
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static bool IsAjaxRequest(this HttpRequest httpRequest)
        {
            if (httpRequest == null)
                throw new ArgumentNullException("request is null");

            if(httpRequest.Headers!=null)
                return httpRequest.Headers["X-Requested-With"] == "XMLHttpRequest";

            return false;
        }

        #region ToUrlSlug
        /// <summary>
        /// String veriyi url formatında geçerli bir stringe dönüştürür
        /// </summary>
        /// <returns>Slug String'i Döndürür.</returns>
        public static string ToUrlSlug(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return Regex.Replace(Regex.Replace(Regex.Replace(text.Trim().ToLower().Replace(" ", "-").Replace("ö", "o").Replace(".", "").Replace("ç", "c").Replace("ş", "s").Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u"), @"\s+", " "), @"\s", ""), @"[^a-z0-9\s-]", "");
            }
            else
            {
                return text;
            }
        }
        #endregion

        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }

        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
                   };
        }
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                   };
        }
        //public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, IList<int> accpetedValues)
        //{
        //    if (accpetedValues == null || !accpetedValues.Any() || string.IsNullOrEmpty(propertyName))
        //        return source;

        //    var item = Expression.Parameter(typeof(T), "item");
        //    var selector = Expression.PropertyOrField(item, propertyName);
        //    var predicate = Expression.Lambda<Func<T, bool>>(
        //        Expression.Call(typeof(Enumerable), "Contains", new[] { typeof(int) },
        //            Expression.Constant(accpetedValues), selector),
        //        item);
        //    return source.Where(predicate);
        //}
        //public static PageResult<T> GetPaged<T>(this IQueryable<T> query,
        //                                 int page, int pageSize) where T : class
        //{

        //    int rowCount = query.Count();
        //    var pageCount = (double)rowCount / pageSize;
        //    var TruePageCount = (int)Math.Ceiling(pageCount);
        //    var result = new PageResult<T>(rowCount, TruePageCount, page, pageSize);
        //    result.CurrentPage = page;
        //    result.PageSize = pageSize;
        //    result.RowCount = rowCount;
        //    result.PageCount = TruePageCount;
        //    var skip = (page - 1) * pageSize;

        //    result.Data = query.Skip(skip).Take(pageSize).ToList();

        //    return result;
        //}
        //public static PagedResult<U> GetPaged<T, U>(this IQueryable<T> query,
        //                                    int page, int pageSize) where U : class
        //{
        //    var result = new PagedResult<U>();
        //    result.CurrentPage = page;
        //    result.PageSize = pageSize;
        //    result.RowCount = query.Count();

        //    var pageCount = (double)result.RowCount / pageSize;
        //    result.PageCount = (int)Math.Ceiling(pageCount);

        //    var skip = (page - 1) * pageSize;
        //    result.Results = query.Skip(skip)
        //                          .Take(pageSize)
        //                          .ProjectTo<U>()
        //                          .ToList();

        //    return result;
        //}
        public static IQueryable<T> Search<T>(this IQueryable<T> source, Expression<Func<T, string>> stringProperty, string searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return source;
            }

            // The below represents the following lamda:
            // source.Where(x => x.[property] != null
            //                && x.[property].Contains(searchTerm))

            //Create expression to represent x.[property] != null
            var isNotNullExpression = Expression.NotEqual(stringProperty.Body,
                                                          Expression.Constant(null));

            //Create expression to represent x.[property].Contains(searchTerm)
            var searchTermExpression = Expression.Constant(searchTerm);
            var checkContainsExpression = Expression.Call(stringProperty.Body, typeof(string).GetMethod("Contains"), searchTermExpression);

            //Join not null and contains expressions
            var notNullAndContainsExpression = Expression.AndAlso(isNotNullExpression, checkContainsExpression);

            var methodCallExpression = Expression.Call(typeof(Queryable),
                                                       "Where",
                                                       new Type[] { source.ElementType },
                                                       source.Expression,
                                                       Expression.Lambda<Func<T, bool>>(notNullAndContainsExpression, stringProperty.Parameters));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }

        public static T ToObject<T>(this IDictionary<string, object> source)
        where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType
                         .GetProperty(item.Key)
                         .SetValue(someObject, item.Value, null);
            }

            return someObject;
        }

        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

        }
    }
}
