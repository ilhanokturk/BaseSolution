using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseSolution.Utilities.Extensions;
using BaseSolution.MVC.Models.Contracts;

namespace BaseSolution.MVC.Filter.Validation
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.IsAjaxRequest())
            {
                if (!context.ModelState.IsValid)
                {
                    var errorsInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                    var errorResponse = new ErrorResponse();

                    foreach (var error in errorsInModelState)
                    {
                        foreach (var value in error.Value)
                        {
                            var errorModel = new ErrorModel
                            {
                                FieldName = error.Key,
                                Message = value
                            };
                            errorResponse.Errors.Add(errorModel);
                        }
                    }
                    foreach (var item in errorResponse.Errors)
                    {
                        context.ModelState.AddModelError(item.FieldName, item.Message);
                    }
                    var controller = context.Controller as Controller;
                    var model = context.ActionArguments?.Count > 0 ? context.ActionArguments.First().Value : null;
                    context.Result = (IActionResult)controller?.View(model); //?? new BadRequestObjectResult(errorResponse);
                    return;
                }
                else
                    await next();
            }
            else
            {
                if (!context.ModelState.IsValid)
                {
                    var errorsInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                    var errorResponse = new ErrorResponse();

                    foreach (var error in errorsInModelState)
                    {
                        foreach (var item in error.Value)
                        {
                            //context.ModelState.AddModelError(error.Key, item);
                            var errorModel = new ErrorModel
                            {
                                FieldName = error.Key,
                                Message = item
                            };
                            errorResponse.Errors.Add(errorModel);
                        }
                    }

                    foreach (var item in errorResponse.Errors)
                    {
                        context.ModelState.AddModelError(item.FieldName, item.Message);
                    }

                    //context.Result = new BadRequestObjectResult(errorResponse);
                    var controller = context.Controller as Controller;
                    var model = context.ActionArguments?.Count > 0 ? context.ActionArguments.First().Value : null;
                    context.Result = (JsonResult)controller?.Json(errorResponse); //?? new BadRequestObjectResult(errorResponse);
                    return;
                }
                await next();
            }
        }
    }
}
