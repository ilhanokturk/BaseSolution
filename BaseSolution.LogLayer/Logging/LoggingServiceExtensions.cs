using BaseSolution.Abstraction.Logging;
using BaseSolution.LogLayer.Logging.Log4Net.Management;
using BaseSolution.LogLayer.Logging.Nlog.Management;
using BaseSolution.Utilities.Enums;
using BaseSolution.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSolution.LogLayer.Logging
{
    public static class LoggingServiceExtensions
    {
        public static IServiceCollection LogDependencyResolvers(this IServiceCollection services)
        {
            //eventLoggingDepencies
            services.AddScoped<ILoggerBase>(x => new Log4NetManager(Log4NetEventLoggerType.DatabaseLogger.DescriptionAttr()));
            //services.AddScoped<ILoggerBase>(x => new NLogManager(NlogEventRepositoryType.DatabaseRepository.DescriptionAttr()));


            //service logging dependencies
            services.AddScoped<ILoggerManager>(x => new NLogManager(NlogEventRepositoryType.FileRepository.DescriptionAttr()));
            //services.AddScoped<ILoggerManager>(x=>new Log4NetManager(Log4NetEventLoggerType.FileLogger.DescriptionAttr()))
            return services;
        }
    }
}
