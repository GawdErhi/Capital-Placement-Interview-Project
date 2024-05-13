using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class QuestionTypeRepository : BaseRepository<QuestionType>, IQuestionTypeRepository
    {
        private readonly ProjectDBContext _dbContext;
        public QuestionTypeRepository(ProjectDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
