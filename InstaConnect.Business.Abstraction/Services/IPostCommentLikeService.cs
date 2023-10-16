using InstaConnect.Business.Models.DTOs.PostCommentLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing post comment likes.
    /// </summary>
    public interface IPostCommentLikeService
    {
        /// <summary>
        /// Retrieves all post comment likes for a specific user and post comment with pagination support.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="amount">The number of likes to retrieve per page.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a collection of <see cref="PostCommentLikeResultDTO"/>.</returns>
        Task<IResult<ICollection<PostCommentLikeResultDTO>>> GetAllAsync(string userId, string postCommentId, int page, int amount);

        /// <summary>
        /// Retrieves a post comment like by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comment like.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="PostCommentLikeResultDTO"/>.</returns>
        Task<IResult<PostCommentLikeResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Retrieves a post comment like by user ID and post comment ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="PostCommentLikeResultDTO"/>.</returns>
        Task<IResult<PostCommentLikeResultDTO>> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId);

        /// <summary>
        /// Adds a new post comment like.
        /// </summary>
        /// <param name="likeAddDTO">The data for the new comment like.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the added <see cref="PostCommentLikeResultDTO"/>.</returns>
        Task<IResult<PostCommentLikeResultDTO>> AddAsync(PostCommentLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a post comment like by user ID and post comment ID.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the comment.</param>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="PostCommentLikeResultDTO"/>.</returns>
        Task<IResult<PostCommentLikeResultDTO>> DeleteByUserIdAndPostCommentIdAsync(string userId, string postCommentId);

        /// <summary>
        /// Deletes a post comment like by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user performing the action.</param>
        /// <param name="id">The unique identifier of the comment like to delete.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="PostCommentLikeResultDTO"/>.</returns>
        Task<IResult<PostCommentLikeResultDTO>> DeleteAsync(string userId, string id);
    }
}
