using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class ProgramCandidateQuestionTypeAnswerRepository : BaseRepository<ProgramCandidateQuestionTypeAnswer>, IProgramCandidateQuestionTypeAnswerRepository
    {
        private readonly ProjectDBContext _dbContext;
        public ProgramCandidateQuestionTypeAnswerRepository(ProjectDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
