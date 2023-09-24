using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;
using System.Linq.Expressions;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing post comments, inheriting from the generic repository for entities of type <see cref="PostComment"/>.
    /// </summary>
    public interface IPostCommentRepository : IRepository<PostComment>
    {
        /// <summary>
        /// Retrieves all post comments including related entities such as users and posts.
        /// </summary>
        /// <returns>A collection of post comments with related entities included.</returns>
        Task<ICollection<PostComment>> GetAllIncludedAsync();

        /// <summary>
        /// Retrieves all post comments that satisfy a specified filter expression, including related entities such as users and posts.
        /// </summary>
        /// <param name="expression">The filter expression used to select post comments.</param>
        /// <returns>A collection of filtered post comments with related entities included.</returns>
        Task<ICollection<PostComment>> GetAllFilteredIncludedAsync(Expression<Func<PostComment, bool>> expression);

        /// <summary>
        /// Finds and retrieves a post comment that matches the specified filter expression, including related entities such as users and posts, asynchronously.
        /// </summary>
        /// <param name="expression">The filter expression used to select the post comment.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns the post comment that satisfies the provided filter, with related entities included.</returns>
        Task<PostComment> FindPostCommentIncludedAsync(Expression<Func<PostComment, bool>> expression);
    }
}
