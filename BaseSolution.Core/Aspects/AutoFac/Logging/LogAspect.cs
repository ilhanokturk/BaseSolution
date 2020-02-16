using BaseSolution.Abstraction.Interceptors;
using BaseSolution.LogLayer.Logging.LogObjects;
using BaseSolution.LogLayer.Logging.Nlog.Management;
using BaseSolution.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BaseSolution.Core.Aspects.AutoFac.Logging
{
    public class LogAspect:MethodInterception
    {
        private readonly NLogManager _logManager;
        private IHttpContextAccessor _contextAccessor;
        public LogAspect(Type loggerType)
        {
            if (loggerType.BaseType != typeof(NLogManager))
                throw new Exception("Invalid Log Type");

            _logManager = (NLogManager)Activator.CreateInstance(loggerType);
            _contextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var logDetail = GetLogDetail(invocation);
            _logManager.Write(Utilities.Enums.ApplicationLogType.Info, logDetail);
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            var logDetail = GetLogDetail(invocation);
            _logManager.Write(Utilities.Enums.ApplicationLogType.Info, logDetail);
        }

        private object GetLogDetail(IInvocation invocation)
        {

            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }
            var logDetail = new LogDetail
            {
                ClassName = invocation.MethodInvocationTarget.DeclaringType.Name,
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,
                ReturnType = invocation.Method?.ReturnType?.FullName,
                CurrentUser = _contextAccessor.HttpContext.User.Identity.IsAuthenticated ? _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email)+"/"+_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role) : "Guest"
            };

            

            return logDetail;
        }
    }
}
