using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.HelperModels;

namespace CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts
{
    public interface ICandidateHandler
    {
        /// <summary>
        /// Validates and Submits candidate application
        /// </summary>
        /// <param name="programCandidate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUserInputException"></exception>
        Task<APIResponseModel<string>> ValidateAndSubmitApplication(ProgramCandidateDTO programCandidate);

        /// <summary>
        /// Get questions for program
        /// </summary>
        /// <param name="programDetailId"></param>
        /// <returns></returns>
        Task<APIResponseModel<object>> GetQuestions(string programDetailId);
    }
}
