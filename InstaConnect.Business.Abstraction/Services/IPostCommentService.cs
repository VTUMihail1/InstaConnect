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
        /// Gets all post comments asynchronously.
        /// </summary>
        /// <returns>A collection of post comment results.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllAsync();

        /// <summary>
        /// Gets all post comments by a specific user asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A collection of post comment results.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Gets all post comments for a specific post asynchronously.
        /// </summary>
        /// <param name="postId">The unique identifier of the post.</param>
        /// <returns>A collection of post comment results.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByPostIdAsync(string postId);

        /// <summary>
        /// Gets all child post comments for a specific parent comment asynchronously.
        /// </summary>
        /// <param name="postCommentId">The unique identifier of the parent comment.</param>
        /// <returns>A collection of post comment results.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByParentIdAsync(string postCommentId);

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