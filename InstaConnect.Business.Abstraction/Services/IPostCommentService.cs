using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Provides methods for managing post comments.
    /// </summary>
    public interface IPostCommentService
    {
        /// <summary>
        /// Retrieves a collection of PostCommentResultDTO for a specific user, post, and post comment.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="postId">The ID of the post.</param>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <returns>A Task representing the asynchronous operation that returns an ICollection of PostCommentResultDTO.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllAsync(string userId, string postId, string postCommentId);

        /// <summary>
        /// Gets a post comment by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post comment.</param>
        /// <returns>A result containing the post comment.</returns>
        Task<IResult<PostCommentResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new post comment asynchronously.
        /// </summary>
        /// <param name="postCommentAddDTO">The data for creating a new post comment.</param>
        /// <returns>A result containing the newly created post comment.</returns>
        Task<IResult<PostCommentResultDTO>> AddAsync(PostCommentAddDTO postCommentAddDTO);

        /// <summary>
        /// Updates a post comment by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post comment.</param>
        /// <param name="postCommentUpdateDTO">The data for updating the post comment.</param>
        /// <returns>A result containing the updated post comment.</returns>
        Task<IResult<PostCommentResultDTO>> UpdateAsync(string id, PostCommentUpdateDTO postCommentUpdateDTO);

        /// <summary>
        /// Deletes a post comment by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post comment.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<PostCommentResultDTO>> DeleteAsync(string id);
    }
}