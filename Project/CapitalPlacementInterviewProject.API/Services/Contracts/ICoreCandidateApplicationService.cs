using CapitalPlacementInterviewProject.API.DTO;

namespace CapitalPlacementInterviewProject.API.Services.Contracts
{
    public interface ICoreCandidateApplicationService
    {
        /// <summary>
        /// Submit program and application
        /// </summary>
        /// <param name="programCandidate"></param>
        /// <returns></returns>
        Task SubmitProgramAndApplication(ProgramCandidateDTO programCandidate);
    }
}
