using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Provides methods for managing comment likes.
    /// </summary>
    public interface ICommentLikeService
    {
        /// <summary>
        /// Gets all comment likes asynchronously.
        /// </summary>
        /// <returns>A collection of comment like results.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllAsync();

        /// <summary>
        /// Gets all comment likes for a specific user asynchronously.
        /// </summary>
        /// <param name="userId">The user's unique identifier.</param>
        /// <returns>A collection of comment like results.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Gets all comment likes for a specific comment asynchronously.
        /// </summary>
        /// <param name="postCommentId">The unique identifier of the comment.</param>
        /// <returns>A collection of comment like results.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllByCommentIdAsync(string postCommentId);

        /// <summary>
        /// Gets a comment like by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the comment like.</param>
        /// <returns>A result containing the comment like.</returns>
        Task<IResult<CommentLikeResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Gets a comment like by comment and user identifiers asynchronously.
        /// </summary>
        /// <param name="postCommentId">The unique identifier of the comment.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A result containing the comment like.</returns>
        Task<IResult<CommentLikeResultDTO>> GetByPostCommentIdAndUserIdAsync(string postCommentId, string userId);

        /// <summary>
        /// Adds a new comment like asynchronously.
        /// </summary>
        /// <param name="likeAddDTO">The data for creating a new comment like.</param>
        /// <returns>A result containing the newly created comment like.</returns>
        Task<IResult<CommentLikeResultDTO>> AddAsync(CommentLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a comment like by comment and user identifiers asynchronously.
        /// </summary>
        /// <param name="postCommentId">The unique identifier of the comment.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<CommentLikeResultDTO>> DeleteByPostCommentIdAndUserIdAsync(string postCommentId, string userId);

        /// <summary>
        /// Deletes a comment like by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the comment like.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<CommentLikeResultDTO>> DeleteAsync(string id);
    }
}
