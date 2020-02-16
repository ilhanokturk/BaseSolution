using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Utilities.ServiceExtensions
{
    public static class ExtensionServices
    {
        public static IServiceCollection AddNLog(this IServiceCollection services)
        {
            return services;
        }
    }
}
