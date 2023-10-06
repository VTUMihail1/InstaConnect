using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing post comments.
    /// </summary>
    public interface IPostCommentService
    {
        /// <summary>
        /// Retrieves all post comments with pagination support based on user ID, post ID, and post comment ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="postId">The ID of the post.</param>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="amount">The number of post comments to retrieve per page.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a collection of <see cref="PostCommentResultDTO"/>.</returns>
        Task<IResult<ICollection<PostCommentResultDTO>>> GetAllAsync(string userId, string postId, string postCommentId, int page, int amount);

        /// <summary>
        /// Retrieves a post comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post comment.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="PostCommentResultDTO"/>.</returns>
        Task<IResult<PostCommentResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new post comment.
        /// </summary>
        /// <param name="postCommentAddDTO">The data for the new post comment.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the added <see cref="PostCommentResultDTO"/>.</returns>
        Task<IResult<PostCommentResultDTO>> AddAsync(PostCommentAddDTO postCommentAddDTO);

        /// <summary>
        /// Updates an existing post comment by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user performing the action.</param>
        /// <param name="id">The unique identifier of the post comment to update.</param>
        /// <param name="postCommentUpdateDTO">The data to update the post comment with.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the updated <see cref="PostCommentResultDTO"/>.</returns>
        Task<IResult<PostCommentResultDTO>> UpdateAsync(string userId, string id, PostCommentUpdateDTO postCommentUpdateDTO);

        /// <summary>
        /// Deletes a post comment by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user performing the action.</param>
        /// <param name="id">The unique identifier of the post comment to delete.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="PostCommentResultDTO"/>.</returns>
        Task<IResult<PostCommentResultDTO>> DeleteAsync(string userId, string id);
    }
}