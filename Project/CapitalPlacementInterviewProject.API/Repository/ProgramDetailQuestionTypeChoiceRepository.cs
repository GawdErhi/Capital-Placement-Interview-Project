using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class ProgramDetailQuestionTypeChoiceRepository : BaseRepository<ProgramDetailQuestionTypeChoice>, IProgramDetailQuestionTypeChoiceRepository
    {
        private readonly ProjectDBContext _dbContext;
        public ProgramDetailQuestionTypeChoiceRepository(ProjectDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
