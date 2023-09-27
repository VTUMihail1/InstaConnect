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
        /// Retrieves all comment likes associated with a user and a post comment.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <returns>A collection of <see cref="CommentLikeResultDTO"/> representing comment likes.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllAsync(string userId, string postCommentId);

        /// <summary>
        /// Retrieves a comment like by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comment like.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="CommentLikeResultDTO"/>.</returns>
        Task<IResult<CommentLikeResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Retrieves a comment like by user ID and post comment ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="CommentLikeResultDTO"/>.</returns>
        Task<IResult<CommentLikeResultDTO>> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId);

        /// <summary>
        /// Adds a new comment like.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="likeAddDTO">The data for the new comment like.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the added <see cref="CommentLikeResultDTO"/>.</returns>
        Task<IResult<CommentLikeResultDTO>> AddAsync(string currentUserId, CommentLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a comment like by user ID and post comment ID.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="userId">The ID of the user who liked the comment.</param>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="CommentLikeResultDTO"/>.</returns>
        Task<IResult<CommentLikeResultDTO>> DeleteByUserIdAndPostCommentIdAsync(string currentUserId, string userId, string postCommentId);

        /// <summary>
        /// Deletes a comment like by its unique identifier.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="id">The unique identifier of the comment like to delete.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="CommentLikeResultDTO"/>.</returns>
        Task<IResult<CommentLikeResultDTO>> DeleteAsync(string currentUserId, string id);
    }
}
