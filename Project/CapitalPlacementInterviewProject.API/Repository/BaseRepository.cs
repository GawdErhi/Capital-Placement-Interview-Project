using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Models;

namespace CapitalPlacementInterviewProject.API.Repository
{
    public class BaseRepository<T> where T : BaseModel
    {
        private readonly ProjectDBContext _dbContext;

        public BaseRepository(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Adds and saves an item to the database entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(T model)
        {
            try
            {
                await _dbContext.AddAsync(model);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds and saves a collections of items to the database entity
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<bool> SaveBundleAsync(IEnumerable<T> models)
        {
            try
            {
                await _dbContext.AddRangeAsync(models);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets entity with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(int id)
        {
            try
            {
                return await _dbContext.FindAsync<T>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T model)
        {
            try
            {
                _dbContext.Update(model);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
