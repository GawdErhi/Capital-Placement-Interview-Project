using CapitalPlacementInterviewProject.API.Models;

namespace CapitalPlacementInterviewProject.API.Repository.Contracts
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        /// <summary>
        /// Adds and saves an item to the database entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SaveAsync(T model);

        /// <summary>
        /// Adds and saves a collections of items to the database entity
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<bool> SaveBundleAsync(IEnumerable<T> models);

        /// <summary>
        /// Gets entity with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);
    }
}
