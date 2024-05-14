using CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts;
using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.Exceptions;
using CapitalPlacementInterviewProject.API.HelperModels;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Controllers.Handlers
{
    public class ApplicationFormBuilderHandler : IApplicationFormBuilderHandler
    {
        private readonly IPersonalInfoFieldRepository _personalInfoFieldRepository;
        private readonly IQuestionTypeRepository _questionTypeRepository;
        public ApplicationFormBuilderHandler(IPersonalInfoFieldRepository personalInfoFieldRepository, IQuestionTypeRepository questionTypeRepository)
        {
            _personalInfoFieldRepository = personalInfoFieldRepository;
            _questionTypeRepository = questionTypeRepository;
        }

        /// <summary>
        /// Create personal info field
        /// </summary>
        /// <param name="personalInfoField"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUserInputException"></exception>
        public async Task<APIResponseModel<string>> CreatePersonalInfoField(PersonalInfoFieldDTO personalInfoField)
        {
            try
            {
                //check if field with same name exists
                if (_personalInfoFieldRepository.Count(x => x.FieldName == personalInfoField.FieldName) > 0) { throw new InvalidUserInputException("Info field already exists"); }

                await _personalInfoFieldRepository.AddAsync(new Models.PersonalInfoField { Id = Guid.NewGuid().ToString(), FieldName = personalInfoField.FieldName });
                await _personalInfoFieldRepository.SaveAsync();

                return new APIResponseModel<string> { Data = "Success" };
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Get personal info fields
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponseModel<object>> GetPersonalInfoFields()
        {
            try
            {
                var personalInfoFields = await _personalInfoFieldRepository.GetCollection();

                return new APIResponseModel<object> { Data = personalInfoFields.Select(x => new PersonalInfoFieldDTO { Id = x.Id, FieldName = x.FieldName }) };
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Create question type
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUserInputException"></exception>
        public async Task<APIResponseModel<string>> CreateQuestionType(QuestionTypeDTO questionType)
        {
            try
            {
                //check if question type with same name already exists
                if(_questionTypeRepository.Count(x => x.Name == questionType.Name) > 0) { throw new InvalidUserInputException("Question type already exists"); }

                await _questionTypeRepository.AddAsync(new Models.QuestionType { Id = Guid.NewGuid().ToString(), Name = questionType.Name });
                await _questionTypeRepository.SaveAsync();

                return new APIResponseModel<string> { Data = "Success" };
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Get question types
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponseModel<object>> GetQuestionTypes()
        {
            try
            {
                var questionTypes = await _questionTypeRepository.GetCollection();

                return new APIResponseModel<object> { Data = questionTypes.Select(x => new QuestionTypeDTO { Id = x.Id, Name = x.Name }) };
            }catch (Exception) { throw; }
        }
    }
}
