using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;
using System.Linq.Expressions;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing comment likes, inheriting from the generic repository for entities of type <see cref="CommentLike"/>.
    /// </summary>
    public interface ICommentLikeRepository : IRepository<CommentLike>
    {
        /// <summary>
        /// Retrieves all comment likes, including related entities.
        /// </summary>
        /// <returns>A collection of comment likes with related entities included.</returns>
        Task<ICollection<CommentLike>> GetAllIncludedAsync();

        /// <summary>
        /// Retrieves all comment likes that satisfy a specified filter expression, including related entities.
        /// </summary>
        /// <param name="expression">The filter expression used to select comment likes.</param>
        /// <returns>A collection of filtered comment likes with related entities included.</returns>
        Task<ICollection<CommentLike>> GetAllFilteredIncludedAsync(Expression<Func<CommentLike, bool>> expression);

        /// <summary>
        /// Finds and retrieves a comment like that matches the specified filter expression, including related entities, asynchronously.
        /// </summary>
        /// <param name="expression">The filter expression used to select the comment like.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns the comment like that satisfies the provided filter, with related entities included.</returns>
        Task<CommentLike> FindIncludedAsync(Expression<Func<CommentLike, bool>> expression);
        // Additional methods for managing CommentLikes can be added here with appropriate documentation.
    }

}
