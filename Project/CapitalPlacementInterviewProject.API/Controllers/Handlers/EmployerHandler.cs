using CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts;
using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.Exceptions;
using CapitalPlacementInterviewProject.API.HelperModels;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;
using CapitalPlacementInterviewProject.API.Services.Contracts;
using ILogger = CapitalPlacementInterviewProject.API.Services.Contracts.ILogger;

namespace CapitalPlacementInterviewProject.API.Controllers.Handlers
{
    public class EmployerHandler : IEmployerHandler
    {
        private readonly IProgramDetailRepository _programDetailRepository;
        private readonly IPersonalInfoFieldRepository _personalInfoFieldRepository;
        private readonly IProgramDetailPersonalInfoFieldRepository _programDetailPersonalInfoFieldRepository;
        private readonly IProgramDetailQuestionTypeRepository _programDetailQuestionTypeRepository;
        private readonly IProgramDetailQuestionTypeChoiceRepository _programDetailQuestionTypeChoiceRepository;
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly ICoreEmployerProgramAndApplicationService _coreEmployerProgramAndApplicationService;
        private readonly ILogger _logger;

        public EmployerHandler(IProgramDetailRepository programDetailRepository, IPersonalInfoFieldRepository personalInfoFieldRepository, IProgramDetailPersonalInfoFieldRepository programDetailPersonalInfoFieldRepository, IProgramDetailQuestionTypeRepository programDetailQuestionTypeRepository, IProgramDetailQuestionTypeChoiceRepository programDetailQuestionTypeChoiceRepository, IQuestionTypeRepository questionTypeRepository, ICoreEmployerProgramAndApplicationService coreEmployerProgramAndApplicationService, ILogger logger)
        {
            _programDetailRepository = programDetailRepository;
            _personalInfoFieldRepository = personalInfoFieldRepository;
            _programDetailPersonalInfoFieldRepository = programDetailPersonalInfoFieldRepository;
            _programDetailQuestionTypeRepository = programDetailQuestionTypeRepository;
            _programDetailQuestionTypeChoiceRepository = programDetailQuestionTypeChoiceRepository;
            _questionTypeRepository = questionTypeRepository;
            _coreEmployerProgramAndApplicationService = coreEmployerProgramAndApplicationService;
            _logger = logger;
        }

        /// <summary>
        /// Validates and then creates program and application form
        /// </summary>
        /// <param name="programDetail"></param>
        /// <returns></returns>
        public async Task<APIResponseModel<string>> ValidateThenCreateProgramAndApplicationForm(ProgramDetailDTO programDetail)
        {
            try
            {
                //validate personal info fields
                if (programDetail.PersonalInfoFields == null || programDetail.PersonalInfoFields.Count == 0) { throw new InvalidUserInputException("No personal info fields selected"); }
                foreach(var personalInfoField in programDetail.PersonalInfoFields)
                {
                    if(_personalInfoFieldRepository.Count(x => x.Id == personalInfoField.PersonalInfoFieldId) <= 0) { throw new InvalidUserInputException("Invalid personal info field selected"); }
                }

                //validate question types
                if(programDetail.Questions != null && programDetail.Questions.Count > 0)
                {
                    foreach(var question in programDetail.Questions)
                    {
                        if (_questionTypeRepository.Count(x => x.Id == question.QuestionTypeId) <= 0) { throw new InvalidUserInputException("Invalid question type selected"); }

                        if(question.Choices != null && question.Choices.Count > 0)
                        {
                            foreach(var choiceObj in question.Choices) { if (string.IsNullOrWhiteSpace(choiceObj.Choice)) { throw new InvalidUserInputException("Choice value cannot be empty"); } }
                        }
                    }

                }

                await _coreEmployerProgramAndApplicationService.CreateProgramAndApplicationForm(programDetail);

                return new APIResponseModel<string> { Data = "Success" };
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Edit question
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        public async Task<APIResponseModel<string>> EditQuestion(ProgramDetailQuestionTypeDTO questionType)
        {
            try
            {
                var questionObj = await _programDetailQuestionTypeRepository.GetAsync(questionType.Id);
                if (questionObj == null) { throw new RecordNotFoundException($"No ProgramDetailQuestionType with id {questionType.Id} found"); }
                questionObj.EnableOtherOption = questionType.EnableOtherOption;
                questionObj.Question = questionType.Question;

                _programDetailQuestionTypeRepository.Update(questionObj);

                return new APIResponseModel<string> { Data = "Success" };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
