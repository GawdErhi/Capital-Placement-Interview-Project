using CapitalPlacementInterviewProject.API.Models;
using System.Linq.Expressions;

namespace CapitalPlacementInterviewProject.API.Repository.Contracts
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        /// <summary>
        /// Adds an item to the database entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(T model);

        /// <summary>
        /// Saves changes made to db context to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SaveAsync();

        /// <summary>
        /// Adds a collections of items to the database entity
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        Task AddBundleAsync(IEnumerable<T> models);

        /// <summary>
        /// Gets entity with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(string id);

        /// <summary>
        /// Gets entity based on condition
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> lambda);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);

        /// <summary>
        /// Returns item count for lambda
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> lambda);

        /// <summary>
        /// Returns all items in entity
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetCollection();
    }
}
