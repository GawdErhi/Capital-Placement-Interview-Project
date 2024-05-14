using CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts;
using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.Exceptions;
using CapitalPlacementInterviewProject.API.HelperModels;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;
using CapitalPlacementInterviewProject.API.Services.Contracts;
using System.Globalization;
using ILogger = CapitalPlacementInterviewProject.API.Services.Contracts.ILogger;

namespace CapitalPlacementInterviewProject.API.Controllers.Handlers
{
    public class CandidateHandler : ICandidateHandler
    {
        private readonly IProgramCandidateRepository _programCandidateRepository;
        private readonly IProgramCandidateQuestionTypeAnswerRepository _questionAnswerRepository;
        private readonly IProgramDetailQuestionTypeRepository _programDetailQuestionTypeRepository;
        private readonly IProgramDetailQuestionTypeChoiceRepository _programDetailQuestionTypeChoiceRepository;
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly ICoreCandidateApplicationService _coreCandidateApplicationService;
        private readonly IProgramDetailRepository _programDetailRepository;
        private readonly ILogger _logger;
        public CandidateHandler(IProgramCandidateRepository programCandidateRepository, IProgramCandidateQuestionTypeAnswerRepository questionAnswerRepository, IProgramDetailQuestionTypeRepository programDetailQuestionTypeRepository, IProgramDetailQuestionTypeChoiceRepository programDetailQuestionTypeChoiceRepository, IQuestionTypeRepository questionTypeRepository, ICoreCandidateApplicationService coreCandidateApplicationService, IProgramDetailRepository programDetailRepository, ILogger logger)
        {
            _programCandidateRepository = programCandidateRepository;
            _questionAnswerRepository = questionAnswerRepository;
            _programDetailQuestionTypeRepository = programDetailQuestionTypeRepository;
            _programDetailQuestionTypeChoiceRepository = programDetailQuestionTypeChoiceRepository;
            _questionTypeRepository = questionTypeRepository;
            _coreCandidateApplicationService = coreCandidateApplicationService;
            _programDetailRepository = programDetailRepository;
            _logger = logger;
        }

        /// <summary>
        /// Validates and Submits candidate application
        /// </summary>
        /// <param name="programCandidate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUserInputException"></exception>
        public async Task<APIResponseModel<string>> ValidateAndSubmitApplication(ProgramCandidateDTO programCandidate)
        {
            try
            {
                //check if program exists
                if (_programDetailRepository.Count(x => x.Id == programCandidate.ProgramDetailId) <= 0) { throw new InvalidUserInputException("Invalid program selected"); }
                //validate question types
                bool hasQuestions = _programDetailQuestionTypeRepository.Count(x => x.ProgramDetailId == programCandidate.ProgramDetailId) > 0;
                if((hasQuestions && programCandidate.Answers == null) || (hasQuestions && programCandidate.Answers.Count == 0)) { throw new InvalidUserInputException("No answers provided for program questions"); }

                foreach (var answer in programCandidate.Answers)
                {
                    if (_programDetailQuestionTypeRepository.Count(x => x.Id == answer.ProgramDetailQuestionTypeId) <= 0) { throw new InvalidUserInputException("Invalid question type submitted"); }
                }

                //submit program and application logic
                await _coreCandidateApplicationService.SubmitProgramAndApplication(programCandidate);

                return new APIResponseModel<string> { Data = "Success" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get questions for program
        /// </summary>
        /// <param name="programDetailId"></param>
        /// <returns></returns>
        public async Task<APIResponseModel<object>> GetQuestions(string programDetailId)
        {
            try
            {
                List<ProgramDetailQuestionTypeDTO> questions = _programDetailQuestionTypeRepository.Get(x => x.ProgramDetailId == programDetailId).Select(x => new ProgramDetailQuestionTypeDTO
                {
                    Id = x.Id,
                    Question = x.Question,
                    QuestionTypeId = x.QuestionTypeId,
                    ProgramDetailId = x.ProgramDetailId,
                    MaxAllowedChoices = x.MaxAllowedChoices,
                    EnableOtherOption = x.EnableOtherOption,
                }).ToList();

                foreach(var question in questions)
                {
                    question.QuestionTypeName = (await _questionTypeRepository.GetAsync(question.QuestionTypeId)).Name;
                    question.Choices = _programDetailQuestionTypeChoiceRepository.Get(x => x.ProgramDetailQuestionTypeId == question.Id).Select(x => new ProgramDetailQuestionTypeChoiceDTO
                    {
                        Id = x.Id,
                        ProgramDetailQuestionTypeId = x.ProgramDetailQuestionTypeId,
                        Choice = x.Choice,
                    }).ToList();
                }

                return new APIResponseModel<object> { Data = questions };

            }catch (Exception)
            {
                throw;
            }
        }
    }
}
