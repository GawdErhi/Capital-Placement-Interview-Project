using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class ProgramDetailRepository : BaseRepository<ProgramDetail>, IProgramDetailRepository
    {
        private readonly ProjectDBContext _dbContext;
        public ProgramDetailRepository(ProjectDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
