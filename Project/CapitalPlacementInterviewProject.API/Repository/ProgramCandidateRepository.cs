using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class ProgramCandidateRepository : BaseRepository<ProgramCandidate>, IProgramCandidateRepository
    {
        private readonly ProjectDBContext _dbContext;
        public ProgramCandidateRepository(ProjectDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
