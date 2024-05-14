using Microsoft.Extensions.DependencyInjection.Extensions;
using CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts;
using CapitalPlacementInterviewProject.API.Controllers.Handlers;

namespace CapitalPlacementInterviewProject.API.Extensions
{
    public static class HandlerExtensions
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.TryAddScoped<IEmployerHandler, EmployerHandler>();
            services.TryAddScoped<ICandidateHandler, CandidateHandler>();
            services.TryAddScoped<IApplicationFormBuilderHandler, ApplicationFormBuilderHandler>();
        }
    }
}
