using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.HelperModels;

namespace CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts
{
    public interface IApplicationFormBuilderHandler
    {
        /// <summary>
        /// Create personal info field
        /// </summary>
        /// <param name="personalInfoField"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUserInputException"></exception>
        Task<APIResponseModel<string>> CreatePersonalInfoField(PersonalInfoFieldDTO personalInfoField);

        /// <summary>
        /// Get personal info fields
        /// </summary>
        /// <returns></returns>
        Task<APIResponseModel<object>> GetPersonalInfoFields();

        /// <summary>
        /// Create question type
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUserInputException"></exception>
        Task<APIResponseModel<string>> CreateQuestionType(QuestionTypeDTO questionType);

        /// <summary>
        /// Get question types
        /// </summary>
        /// <returns></returns>
        Task<APIResponseModel<object>> GetQuestionTypes();
    }
}
