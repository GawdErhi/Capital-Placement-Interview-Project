using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.HelperModels;

namespace CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts
{
    public interface IEmployerHandler
    {
        /// <summary>
        /// Validates and then creates program and application form
        /// </summary>
        /// <param name="programDetail"></param>
        /// <returns></returns>
        Task<APIResponseModel<string>> ValidateThenCreateProgramAndApplicationForm(ProgramDetailDTO programDetail);

        /// <summary>
        /// Edit question
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        Task<APIResponseModel<string>> EditQuestion(ProgramDetailQuestionTypeDTO questionType);
    }
}
