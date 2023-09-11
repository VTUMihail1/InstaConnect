using System.Linq.Expressions;

namespace InstaConnect.Data.Abstraction.Repositories.Base
{
    /// <summary>
    /// Represents a generic repository interface for performing CRUD (Create, Read, Update, Delete) operations on entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity that this repository works with.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Asynchronously adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Asynchronously deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Asynchronously finds an entity in the repository based on a given expression.
        /// </summary>
        /// <param name="expression">The expression used to find the entity.</param>
        /// <returns>A task representing the asynchronous operation and returning the found entity, or null if not found.</returns>
        Task<T> FindEntityAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Asynchronously retrieves all entities of type <typeparamref name="T"/> from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation and returning a collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves all entities of type <typeparamref name="T"/> from the repository based on a given expression.
        /// </summary>
        /// <param name="expression">The expression used to filter the entities.</param>
        /// <returns>A task representing the asynchronous operation and returning a collection of filtered entities.</returns>
        Task<IEnumerable<T>> GetAllFilteredAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Asynchronously updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(T entity);
    }
}