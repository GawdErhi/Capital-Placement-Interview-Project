using CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts;
using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.HelperModels;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;
using System.Globalization;
using ILogger = CapitalPlacementInterviewProject.API.Services.Contracts.ILogger;

namespace CapitalPlacementInterviewProject.API.Controllers.Handlers
{
    public class CandidateHandler : ICandidateHandler
    {
        private readonly IProgramCandidateRepository _programCandidateRepository;
        private readonly IProgramCandidateQuestionTypeAnswerRepository _questionAnswerRepository;
        private readonly ILogger _logger;
        public CandidateHandler(IProgramCandidateRepository programCandidateRepository, IProgramCandidateQuestionTypeAnswerRepository questionAnswerRepository, ILogger logger)
        {
            _programCandidateRepository = programCandidateRepository;
            _questionAnswerRepository = questionAnswerRepository;
            _logger = logger;
        }

        public async Task<APIResponseModel<string>> SubmitApplication(ProgramCandidateDTO programCandidate)
        {
            try
            {
                ProgramCandidate candidate = new ProgramCandidate
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = programCandidate.FirstName,
                    LastName = programCandidate.LastName,
                    Email = programCandidate.Email,
                    CurrentResidence = programCandidate.CurrentResidence,
                    PhoneNumber = programCandidate.PhoneNumber,
                    Nationality = programCandidate.Nationality,
                    IdNumber = programCandidate.IdNumber,
                    DateOfBirth = DateTime.ParseExact(programCandidate.DateOfBirth, "d", CultureInfo.InvariantCulture),
                    Gender = programCandidate.Gender,
                    ProgramDetailId = programCandidate.ProgramDetailId,
                };

                await _programCandidateRepository.AddAsync(candidate);

                List<ProgramCandidateQuestionTypeAnswer> answers = new List<ProgramCandidateQuestionTypeAnswer>();
                Parallel.ForEach(programCandidate.Answers, (answerObj) =>
                {
                    answers.Add(new ProgramCandidateQuestionTypeAnswer { Id = Guid.NewGuid().ToString(), ProgramCandidateId = candidate.Id, ProgramDetailQuestionTypeId = answerObj.ProgramDetailQuestionTypeId, Answer = answerObj.Answer });
                });

                await _questionAnswerRepository.AddBundleAsync(answers);

                await _programCandidateRepository.SaveAsync();

                return new APIResponseModel<string> { Data = "Success" };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
