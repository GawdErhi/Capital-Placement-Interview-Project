using CapitalPlacementInterviewProject.API.DTO;

namespace CapitalPlacementInterviewProject.API.Services.Contracts
{
    public interface ICoreEmployerProgramAndApplicationService
    {
        /// <summary>
        /// Create program and application form
        /// </summary>
        /// <param name="programDetail"></param>
        /// <returns></returns>
        Task CreateProgramAndApplicationForm(ProgramDetailDTO programDetail);
    }
}
