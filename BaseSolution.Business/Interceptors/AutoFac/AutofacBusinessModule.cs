using Autofac;
using Autofac.Extras.DynamicProxy;
using BaseSolution.Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BaseSolution.Business.Interceptors.AutoFac
{
   public class AutofacBusinessModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
