#pragma checksum "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "968de1a84c4e932084a6f363fbd2279151e18e35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Categories), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Categories.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\_ViewImports.cshtml"
using BaseSolution.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\_ViewImports.cshtml"
using BaseSolution.DTO.DataTransferObjects.User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\_ViewImports.cshtml"
using BaseSolution.DTO.DataTransferObjects.Category;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\_ViewImports.cshtml"
using BaseSolution.DTO.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\_ViewImports.cshtml"
using BaseSolution.DTO.Filter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\_ViewImports.cshtml"
using BaseSolution.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
using BaseSolution.MVC.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"968de1a84c4e932084a6f363fbd2279151e18e35", @"/Areas/Admin/Views/Category/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcab75b4a9be4fbd2e51ebc7aed4561e7b32c7b1", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginationAndFilterDataViewModel<CategoryListDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Categories", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
  
    ViewData["Title"] = "CategoryListWithPaging";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("Css", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "968de1a84c4e932084a6f363fbd2279151e18e357405", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "968de1a84c4e932084a6f363fbd2279151e18e358641", async() => {
                WriteLiteral(@"

    <div class=""content-grids"">
        <div class=""col-md-8 content-main"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <table class=""table m-md-b-0"">
                        <thead class=""thead-inverse"">
                            <tr>
                                <th>#</th>
                                <th>Id</th>
                                <th>Name</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 33 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                             foreach (var item in Model.Data.Result)
                            {
                                var count = 1;

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n                                    <td scope=\"row\">");
#nullable restore
#line 37 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                               Write(count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 38 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 39 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 41 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                count++;
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-12 col-sm-12 m-b-1 m-md-b-0"">
                    <div class=""col-md-4 col-sm-4 items-info"">
");
#nullable restore
#line 50 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                          
                            //var info = string.Format("Items {0} to {1} of {2} total", Model.Pagination.FirstRowOnPage, Model.Pagination.LastRowOnPage, Model.Pagination.RowCount);
                            string info = _localizer.GetLocalizedHtmlString("Items {0} to {1} of {2} total");
                            var informationTable = string.Format(info, Model.Pagination.FirstRowOnPage, Model.Pagination.LastRowOnPage, Model.Pagination.RowCount);
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
#nullable restore
#line 56 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                   Write(informationTable);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                    </div>\r\n                    <div>\r\n");
#nullable restore
#line 60 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                         if (Model.Pagination.PageCount > 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <ul class=\"pagination m-a-0\">\r\n");
#nullable restore
#line 63 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                 if (Model.Pagination.CurrentPage != 1)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <li class=\"page-item\">\r\n                                        <button type=\"submit\" name=\"page\"");
                BeginWriteAttribute("value", " value=\"", 2975, "\"", 3009, 1);
#nullable restore
#line 66 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
WriteAttributeValue("", 2983, Model.Pagination.FistPage, 2983, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"page-link\" aria-label=\"First\">\r\n                                            <span aria-hidden=\"true\">");
#nullable restore
#line 67 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                                Write(_localizer.GetLocalizedHtmlString("First"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                            <span class=\"sr-only\">");
#nullable restore
#line 68 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                             Write(_localizer.GetLocalizedHtmlString("First"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                        </button>\r\n                                    </li>\r\n                                    <li class=\"page-item\">\r\n                                        <button type=\"submit\" name=\"page\"");
                BeginWriteAttribute("value", " value=\"", 3516, "\"", 3554, 1);
#nullable restore
#line 72 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
WriteAttributeValue("", 3524, Model.Pagination.PreviousPage, 3524, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"page-link\" aria-label=\"Previous\">\r\n                                            <span aria-hidden=\"true\">");
#nullable restore
#line 73 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                                Write(_localizer.GetLocalizedHtmlString("Previous"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                            <span class=\"sr-only\">");
#nullable restore
#line 74 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                             Write(_localizer.GetLocalizedHtmlString("Previous"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                        </button>\r\n                                    </li>\r\n");
#nullable restore
#line 77 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                 for (var i = Model.Pagination.StartIndex; i <= Model.Pagination.FinishedIndex; i++)
                                {
                                    if (Model.Pagination.CurrentPage == i)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li class=\"page-item active\"><button class=\"page-link disabled\"");
                BeginWriteAttribute("value", " value=\"", 4343, "\"", 4353, 1);
#nullable restore
#line 82 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
WriteAttributeValue("", 4351, i, 4351, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 82 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                                                                              Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button></li>\r\n");
#nullable restore
#line 83 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li class=\"page-item\"><button type=\"submit\" name=\"page\"");
                BeginWriteAttribute("value", " value=\"", 4588, "\"", 4598, 1);
#nullable restore
#line 86 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
WriteAttributeValue("", 4596, i, 4596, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"page-link\">");
#nullable restore
#line 86 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                                                                                        Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button></li>\r\n");
#nullable restore
#line 87 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                    }

                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                 if (Model.Pagination.CurrentPage != Model.Pagination.FinishedIndex)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <li class=\"page-item\">\r\n                                        <button type=\"submit\" name=\"page\"");
                BeginWriteAttribute("value", " value=\"", 4982, "\"", 5016, 1);
#nullable restore
#line 93 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
WriteAttributeValue("", 4990, Model.Pagination.LastPage, 4990, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"page-link\" href=\"#\" aria-label=\"Next\">\r\n                                            <span aria-hidden=\"true\">");
#nullable restore
#line 94 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                                Write(_localizer.GetLocalizedHtmlString("Next"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                            <span class=\"sr-only\">");
#nullable restore
#line 95 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                             Write(_localizer.GetLocalizedHtmlString("NExt"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                        </button>\r\n                                    </li>\r\n                                    <li class=\"page-item\">\r\n                                        <button type=\"submit\" name=\"page\" class=\"page-link\"");
                BeginWriteAttribute("value", " value=\"", 5547, "\"", 5586, 1);
#nullable restore
#line 99 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
WriteAttributeValue("", 5555, Model.Pagination.FinishedIndex, 5555, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" aria-label=\"Last\">\r\n                                            <span aria-hidden=\"true\">");
#nullable restore
#line 100 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                                Write(_localizer.GetLocalizedHtmlString("Last"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                            <span class=\"sr-only\">");
#nullable restore
#line 101 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                             Write(_localizer.GetLocalizedHtmlString("Last"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                        </button>\r\n                                    </li>\r\n");
#nullable restore
#line 104 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </ul>\r\n");
#nullable restore
#line 106 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-4 content-right"">
           <div class=""box box-block"">
               <h5>Filtre</h5>
               <hr />
               <div class=""row"">
");
#nullable restore
#line 117 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                    foreach (var item in Model.Filters.Filter)
                   {

#line default
#line hidden
#nullable disable
                WriteLiteral("                       <div class=\"form-group\">\r\n                           <label for=\"txtCategoryName\">");
#nullable restore
#line 120 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                           <input type=\"text\" class=\"form-control\" id=\"txtCategoryName\"");
                BeginWriteAttribute("name", " name=\"", 6599, "\"", 6616, 1);
#nullable restore
#line 121 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
WriteAttributeValue("", 6606, item.Name, 6606, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 6617, "\"", 6636, 1);
#nullable restore
#line 121 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
WriteAttributeValue("", 6625, item.Value, 6625, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                       </div>\r\n");
#nullable restore
#line 123 "C:\Users\child\source\repos\BaseSolution\BaseSolution.MVC\Areas\Admin\Views\Category\Categories.cshtml"
                   }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n               </div>\r\n               <div class=\"row\">\r\n                   <button type=\"submit\" class=\"btn btn-primary\">Uygula</button>\r\n               </div>\r\n           </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService _localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor _accessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginationAndFilterDataViewModel<CategoryListDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
