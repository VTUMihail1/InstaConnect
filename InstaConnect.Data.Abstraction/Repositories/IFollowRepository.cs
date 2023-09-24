using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;
using System.Linq.Expressions;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing follows, inheriting from the generic repository for entities of type <see cref="Follow"/>.
    /// </summary>
    public interface IFollowRepository : IRepository<Follow>
    {
        /// <summary>
        /// Retrieves all follows, including related entities.
        /// </summary>
        /// <returns>A collection of follows with related entities included.</returns>
        Task<ICollection<Follow>> GetAllIncludedAsync();

        /// <summary>
        /// Retrieves all follows that satisfy a specified filter expression, including related entities.
        /// </summary>
        /// <param name="expression">The filter expression used to select follows.</param>
        /// <returns>A collection of filtered follows with related entities included.</returns>
        Task<ICollection<Follow>> GetAllFilteredIncludedAsync(Expression<Func<Follow, bool>> expression);

        /// <summary>
        /// Finds and retrieves a follow that matches the specified filter expression, including related entities, asynchronously.
        /// </summary>
        /// <param name="expression">The filter expression used to select the follow.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns the follow that satisfies the provided filter, with related entities included.</returns>
        Task<Follow> FindFollowIncludedAsync(Expression<Func<Follow, bool>> expression);
        // Additional methods for managing Follows can be added here with appropriate documentation.
    }

}
