﻿using System.Linq.Expressions;

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
        /// Retrieves a collection of items based on the specified expression, with optional pagination.
        /// </summary>
        /// <param name="expression">The expression used to filter items.</param>
        /// <param name="skipAmount">The number of items to skip (optional, defaults to zero).</param>
        /// <param name="takeAmount">The maximum number of items to retrieve (optional, defaults to maximum value).</param>
        /// <returns>An <see cref="Task"/> representing the asynchronous operation, containing a collection of items of type <typeparamref name="T"/>.</returns>
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression, int skipAmount = default, int takeAmount = int.MaxValue);

        /// <summary>
        /// Asynchronously updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(T entity);
    }
}