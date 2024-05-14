using Microsoft.Extensions.DependencyInjection.Extensions;
using CapitalPlacementInterviewProject.API.Services.Contracts;
using CapitalPlacementInterviewProject.API.Services;

namespace CapitalPlacementInterviewProject.API.Extensions
{
    public static class CoreServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.TryAddScoped<ICoreEmployerProgramAndApplicationService, CoreEmployerProgramAndApplicationService>();
            services.TryAddScoped<ICoreCandidateApplicationService, CoreCandidateApplicationService>();
        }
    }
}
