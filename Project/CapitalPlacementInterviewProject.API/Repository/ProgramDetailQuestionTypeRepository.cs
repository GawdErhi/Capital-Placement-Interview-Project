using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class ProgramDetailQuestionTypeRepository : BaseRepository<ProgramDetailQuestionType>, IProgramDetailQuestionTypeRepository
    {
        private readonly ProjectDBContext _dbContext;
        public ProgramDetailQuestionTypeRepository(ProjectDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
