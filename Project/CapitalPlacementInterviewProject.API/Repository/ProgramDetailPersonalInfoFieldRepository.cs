using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class ProgramDetailPersonalInfoFieldRepository : BaseRepository<ProgramDetailPersonalInfoField>, IProgramDetailPersonalInfoFieldRepository
    {
        private readonly ProjectDBContext _dbContext;
        public ProgramDetailPersonalInfoFieldRepository(ProjectDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
