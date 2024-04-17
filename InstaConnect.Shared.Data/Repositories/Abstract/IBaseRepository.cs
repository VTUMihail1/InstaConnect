using InstaConnect.Shared.Data.Models.Base;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Shared.Data.Repositories.Abstract
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
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>An asynchronous operation representing the deletion of the entity from the repository.</returns>
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to be retrieved.</param>
        /// <returns>An asynchronous operation representing the retrieval of the entity by its unique identifier.</returns>
        Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<ICollection<TEntity>> GetAllAsync(CollectionQuery collectionQuery, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<ICollection<TEntity>> GetAllFilteredAsync(FilteredCollectionQuery<TEntity> filteredCollectionQuery, CancellationToken cancellationToken);

        Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken);

        Task UpdateRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken);

        Task DeleteRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken);
    }
}