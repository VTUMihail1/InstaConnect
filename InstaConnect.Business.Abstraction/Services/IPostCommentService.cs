using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing comments.
    /// </summary>
    public interface IPostCommentService
    {
        /// <summary>
        /// Retrieves all post comments associated with a user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of comment results.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all post comments associated with a post asynchronously.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>A collection of comment results.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByPostIdAsync(string postId);

        /// <summary>
        /// Retrieves all comments associated with a post comment asynchronously.
        /// </summary>
        /// <param name="postCommentId">The ID of the post comment.</param>
        /// <returns>A collection of post comment results.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByIdAsync(string postCommentId);

        /// <summary>
        /// Adds a new post comment asynchronously.
        /// </summary>
        /// <param name="postCommentAddDTO">The data for adding a new post comment.</param>
        /// <returns>The result of the post comment addition operation.</returns>
        Task<IResult<PostCommentResultDTO>> AddAsync(PostCommentAddDTO postCommentAddDTO);

        /// <summary>
        /// Updates an existing post comment asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post comment to update.</param>
        /// <param name="postCommentUpdateDTO">The data for updating the post comment.</param>
        /// <returns>The result of the post comment update operation.</returns>
        Task<IResult<PostCommentResultDTO>> UpdateAsync(string id, PostCommentUpdateDTO postCommentUpdateDTO);

        /// <summary>
        /// Deletes a post comment asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post comment to delete.</param>
        /// <returns>The result of the post comment deletion operation.</returns>
        Task<IResult<PostCommentResultDTO>> DeleteAsync(string id);
    }
}