using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing comment likes.
    /// </summary>
    public interface ICommentLikeService
    {
        /// <summary>
        /// Gets a collection of detailed comment likes asynchronously.
        /// </summary>
        /// <returns>A collection of detailed comment likes.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetDetailedAllAsync();

        /// <summary>
        /// Gets a collection of detailed comment likes by user ID asynchronously.
        /// </summary>
        /// <param name="userId">The user ID to filter comment likes by.</param>
        /// <returns>A collection of detailed comment likes filtered by user ID.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetDetailedAllByUserIdAsync(string userId);

        /// <summary>
        /// Gets a collection of detailed comment likes by comment ID asynchronously.
        /// </summary>
        /// <param name="postCommentId">The comment ID to filter comment likes by.</param>
        /// <returns>A collection of detailed comment likes filtered by comment ID.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetDetailedAllByCommentIdAsync(string postCommentId);

        /// <summary>
        /// Gets a detailed comment like by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the comment like to retrieve.</param>
        /// <returns>A result containing the detailed comment like or a not found result if not found.</returns>
        Task<IResult<CommentLikeResultDTO>> GetDetailedByIdAsync(string id);

        /// <summary>
        /// Gets a collection of comment likes asynchronously.
        /// </summary>
        /// <returns>A collection of comment likes.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllAsync();

        /// <summary>
        /// Gets a collection of comment likes by user ID asynchronously.
        /// </summary>
        /// <param name="userId">The user ID to filter comment likes by.</param>
        /// <returns>A collection of comment likes filtered by user ID.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Gets a collection of comment likes by comment ID asynchronously.
        /// </summary>
        /// <param name="postCommentId">The comment ID to filter comment likes by.</param>
        /// <returns>A collection of comment likes filtered by comment ID.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllByCommentIdAsync(string postCommentId);

        /// <summary>
        /// Gets a comment like by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the comment like to retrieve.</param>
        /// <returns>A result containing the comment like or a not found result if not found.</returns>
        Task<IResult<CommentLikeResultDTO>> GetByIdAsync(string id);


        /// <summary>
        /// Adds a new comment like asynchronously.
        /// </summary>
        /// <param name="likeAddDTO">The data for adding a new comment like.</param>
        /// <returns>The result of the comment like addition operation.</returns>
        Task<IResult<CommentLikeResultDTO>> AddAsync(CommentLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a comment like asynchronously based on the post post comment ID and user ID.
        /// </summary>
        /// <param name="postCommentId">The ID of the post comment for which the like will be deleted.</param>
        /// <param name="userId">The ID of the user who liked the comment.</param>
        /// <returns>The result of the comment like deletion operation.</returns>
        Task<IResult<CommentLikeResultDTO>> DeleteByPostCommentIdAndUserIdAsync(string postCommentId, string userId);

        /// <summary>
        /// Deletes a comment like asynchronously.
        /// </summary>
        /// <param name="id">The ID of the comment like to delete.</param>
        /// <returns>The result of the comment like deletion operation.</returns>
        Task<IResult<CommentLikeResultDTO>> DeleteAsync(string id);
    }
}
