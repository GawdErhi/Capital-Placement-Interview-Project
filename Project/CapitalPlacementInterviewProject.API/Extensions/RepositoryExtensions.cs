using CapitalPlacementInterviewProject.API.Repository;
using CapitalPlacementInterviewProject.API.Repository.Contracts;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CapitalPlacementInterviewProject.API.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.TryAddScoped<IPersonalInfoFieldRepository, PersonalInfoFieldRepository>();
            services.TryAddScoped<IProgramCandidateQuestionTypeAnswerRepository, ProgramCandidateQuestionTypeAnswerRepository>();
            services.TryAddScoped<IProgramCandidateRepository, ProgramCandidateRepository>();
            services.TryAddScoped<IProgramDetailPersonalInfoFieldRepository, ProgramDetailPersonalInfoFieldRepository>();
            services.TryAddScoped<IProgramDetailQuestionTypeChoiceRepository, ProgramDetailQuestionTypeChoiceRepository>();
            services.TryAddScoped<IProgramDetailQuestionTypeRepository, ProgramDetailQuestionTypeRepository>();
            services.TryAddScoped<IProgramDetailRepository, ProgramDetailRepository>();
            services.TryAddScoped<IQuestionTypeRepository, QuestionTypeRepository>();
        }
    }
}
