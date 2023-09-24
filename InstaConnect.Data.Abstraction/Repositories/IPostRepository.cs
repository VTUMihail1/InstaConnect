using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;
using System.Linq.Expressions;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing posts, inheriting from the generic repository for entities of type <see cref="Post"/>.
    /// </summary>
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// Retrieves all posts including related entities such as users, comments, and likes.
        /// </summary>
        /// <returns>A collection of posts with related entities included.</returns>
        Task<ICollection<Post>> GetAllIncludedAsync();

        /// <summary>
        /// Retrieves all posts that satisfy a specified filter expression, including related entities such as users, comments, and likes.
        /// </summary>
        /// <param name="expression">The filter expression used to select posts.</param>
        /// <returns>A collection of filtered posts with related entities included.</returns>
        Task<ICollection<Post>> GetAllFilteredIncludedAsync(Expression<Func<Post, bool>> expression);

        /// <summary>
        /// Finds and retrieves a post that matches the specified filter expression, including related entities such as users, comments, and likes, asynchronously.
        /// </summary>
        /// <param name="expression">The filter expression used to select the post.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns the post that satisfies the provided filter, with related entities included.</returns>
        Task<Post> FindIncludedAsync(Expression<Func<Post, bool>> expression);

    }
}
