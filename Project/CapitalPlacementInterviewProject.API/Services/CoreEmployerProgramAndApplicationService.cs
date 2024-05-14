using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.Exceptions;
using CapitalPlacementInterviewProject.API.HelperModels;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;
using CapitalPlacementInterviewProject.API.Services.Contracts;
using ILogger = CapitalPlacementInterviewProject.API.Services.Contracts.ILogger;

namespace CapitalPlacementInterviewProject.API.Services
{
    public class CoreEmployerProgramAndApplicationService : ICoreEmployerProgramAndApplicationService
    {
        private readonly IProgramDetailRepository _programDetailRepository;
        private readonly IPersonalInfoFieldRepository _personalInfoFieldRepository;
        private readonly IProgramDetailPersonalInfoFieldRepository _programDetailPersonalInfoFieldRepository;
        private readonly IProgramDetailQuestionTypeRepository _programDetailQuestionTypeRepository;
        private readonly IProgramDetailQuestionTypeChoiceRepository _programDetailQuestionTypeChoiceRepository;
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly ILogger _logger;

        public CoreEmployerProgramAndApplicationService(IProgramDetailRepository programDetailRepository, IPersonalInfoFieldRepository personalInfoFieldRepository, IProgramDetailPersonalInfoFieldRepository programDetailPersonalInfoFieldRepository, IProgramDetailQuestionTypeRepository programDetailQuestionTypeRepository, IProgramDetailQuestionTypeChoiceRepository programDetailQuestionTypeChoiceRepository, IQuestionTypeRepository questionTypeRepository, ILogger logger)
        {
            _programDetailRepository = programDetailRepository;
            _personalInfoFieldRepository = personalInfoFieldRepository;
            _programDetailPersonalInfoFieldRepository = programDetailPersonalInfoFieldRepository;
            _programDetailQuestionTypeRepository = programDetailQuestionTypeRepository;
            _programDetailQuestionTypeChoiceRepository = programDetailQuestionTypeChoiceRepository;
            _questionTypeRepository = questionTypeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Create program and application form
        /// </summary>
        /// <param name="programDetail"></param>
        /// <returns></returns>
        public async Task CreateProgramAndApplicationForm(ProgramDetailDTO programDetail)
        {
            try
            {
                var programDetailModel = new ProgramDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = programDetail.Title,
                    Description = programDetail.Description,
                };

                await _programDetailRepository.AddAsync(programDetailModel);

                List<ProgramDetailPersonalInfoField> programDetailPersonalInfoFields = programDetail.PersonalInfoFields.Select(x => new ProgramDetailPersonalInfoField
                {
                    Id = Guid.NewGuid().ToString(),
                    ProgramDetailId = programDetailModel.Id,
                    PersonalInfoFieldId = x.PersonalInfoFieldId,
                    Internal = x.Internal
                }).ToList();

                await _programDetailPersonalInfoFieldRepository.AddBundleAsync(programDetailPersonalInfoFields);

                List<ProgramDetailQuestionType> questions = new List<ProgramDetailQuestionType>();
                List<ProgramDetailQuestionTypeChoice> choices = new List<ProgramDetailQuestionTypeChoice>();

                Parallel.ForEach(programDetail.Questions, (question) =>
                {
                    string programDetailQuestionTypeId = Guid.NewGuid().ToString();

                    //add question type
                    questions.Add(new ProgramDetailQuestionType
                    {
                        Id = programDetailQuestionTypeId,
                        ProgramDetailId = programDetailModel.Id,
                        QuestionTypeId = question.QuestionTypeId,
                        Question = question.Question,
                        MaxAllowedChoices = question.MaxAllowedChoices,
                        EnableOtherOption = question.EnableOtherOption,
                    });

                    //build choices list for question type if any
                    if (question.Choices != null && question.Choices.Any())
                    {
                        choices.AddRange(question.Choices.Select(choice => new ProgramDetailQuestionTypeChoice { Id = Guid.NewGuid().ToString(), ProgramDetailQuestionTypeId = programDetailQuestionTypeId, Choice = choice.Choice }));
                    }
                });

                await _programDetailQuestionTypeRepository.AddBundleAsync(questions);

                await _programDetailQuestionTypeChoiceRepository.AddBundleAsync(choices);

                await _programDetailRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
