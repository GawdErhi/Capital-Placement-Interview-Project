using log4net.Config;
using log4net;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace CapitalPlacementInterviewProject.API.Extensions
{
    public static class LoggerExtensions
    {
        public static void AddLog4NetLogger(this IServiceCollection services)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            services.TryAddSingleton<Services.Contracts.ILogger, Services.Logger>();
        }
    }
}
