using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;
using System.Linq.Expressions;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing post likes, inheriting from the generic repository for entities of type <see cref="PostLike"/>.
    /// </summary>
    public interface IPostLikeRepository : IRepository<PostLike>
    {
        /// <summary>
        /// Retrieves all post likes, including related entities.
        /// </summary>
        /// <returns>A collection of post likes with related entities included.</returns>
        Task<ICollection<PostLike>> GetAllIncludedAsync();

        /// <summary>
        /// Retrieves all post likes that satisfy a specified filter expression, including related entities.
        /// </summary>
        /// <param name="expression">The filter expression used to select post likes.</param>
        /// <returns>A collection of filtered post likes with related entities included.</returns>
        Task<ICollection<PostLike>> GetAllFilteredIncludedAsync(Expression<Func<PostLike, bool>> expression);

        /// <summary>
        /// Finds and retrieves a post like that matches the specified filter expression, including related entities, asynchronously.
        /// </summary>
        /// <param name="expression">The filter expression used to select the post like.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns the post like that satisfies the provided filter, with related entities included.</returns>
        Task<PostLike> FindIncludedAsync(Expression<Func<PostLike, bool>> expression);
        // Additional methods for managing PostLikes can be added here with appropriate documentation.
    }

}
