using BaseSolution.Abstraction.Logging;
using BaseSolution.LogLayer.Logging.LogObjects;
using BaseSolution.LogLayer.Logging.Nlog.Management;
using BaseSolution.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSolution.MVC.Filter.EventLog
{
    public class EventLogFilter : Attribute, IActionFilter
    {
        private readonly ILoggerBase _logger;
        public EventLogFilter(/*ILoggerBase logger*/ Type logger)
        {
            if (logger.BaseType != typeof(NLogManager))
                throw new ArgumentException("Wrong log type");

            _logger = (ILoggerBase)Activator.CreateInstance(logger);

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var logParams = new List<LogParameter>();
            if (context.ActionDescriptor.Parameters.Any())
            {
                foreach (var item in context.ActionDescriptor.Parameters)
                {
                    var _param = new LogParameter();
                    _param.Name = item.Name;
                    _param.Type = item.ParameterType.Name;
                    //_param.Value = context..Where(x => x.Key == _param.Name).FirstOrDefault().Value;
                    var _result = context.Result;
                    if (_result is ViewResult viewResult)
                    {
                        var hebele = viewResult.ViewData.Model;
                        _param.Value = hebele;

                    }
                    else if (_result is JsonResult jsonResult)
                    {
                        var hebele = jsonResult.Value;
                        _param.Value = hebele;
                    }
                    logParams.Add(_param);
                }
            }
            var logDetail = new LogDetail();
            logDetail.ClassName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
            logDetail.MethodName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;
            var result = context.Result as ViewResult;
            logDetail.ReturnType = result?.ViewData?.Model?.GetType().ToString() ?? null;
            logDetail.LogParameters = logParams;

            _logger.Write(ApplicationLogType.Info, logDetail);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var logParams = new List<LogParameter>();
            if (context.ActionDescriptor.Parameters.Any())
            {
                foreach (var item in context.ActionDescriptor.Parameters)
                {
                    var _param = new LogParameter();
                    _param.Name = item.Name;
                    _param.Type = item.ParameterType.Name;
                    _param.Value = context.ActionArguments.Where(x => x.Key == _param.Name).FirstOrDefault().Value;
                    logParams.Add(_param);
                }
            }
            var logDetail = new LogDetail();
            logDetail.ClassName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
            logDetail.MethodName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;
            var result = context.Result as ViewResult;
            logDetail.ReturnType = result?.ViewData?.Model?.GetType().ToString() ?? null;
            logDetail.LogParameters = logParams;
        }
    }
}
