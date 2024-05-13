using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;
using CapitalPlacementInterviewProject.API.Repository.Contracts;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class PersonalInfoFieldRepository : BaseRepository<PersonalInfoField>, IPersonalInfoFieldRepository
    {
        private readonly ProjectDBContext _dbContext;
        public PersonalInfoFieldRepository(ProjectDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
