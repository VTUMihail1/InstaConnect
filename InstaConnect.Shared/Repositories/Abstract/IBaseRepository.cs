using InstaConnect.Shared.Models.Base;
using InstaConnect.Shared.Models.Filter;
using System.Linq.Expressions;

namespace InstaConnect.Shared.Repositories.Abstract
{
    /// <summary>
    /// Represents a generic repository interface for basic CRUD operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that this repository works with. Must implement <see cref="IBaseEntity"/>.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        /// <summary>
        /// Asynchronously adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>An asynchronous operation representing the addition of the entity to the repository.</returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Asynchronously deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>An asynchronous operation representing the deletion of the entity from the repository.</returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Asynchronously retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to be retrieved.</param>
        /// <returns>An asynchronous operation representing the retrieval of the entity by its unique identifier.</returns>
        Task<TEntity?> GetByIdAsync(string id);
        Task<ICollection<TEntity>> GetAllAsync(Collection collectionQuery);
        Task UpdateAsync(TEntity entity);
        Task<ICollection<TEntity>> GetAllFilteredAsync(FilteredCollection<TEntity> filteredCollectionQuery);

        Task AddRangeAsync(ICollection<TEntity> entities);

        Task UpdateRangeAsync(ICollection<TEntity> entities);

        Task DeleteRangeAsync(ICollection<TEntity> entities);
    }
}