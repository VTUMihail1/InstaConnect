using InstaConnect.Business.Models.DTOs.Comment;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing comments.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Retrieves all comments associated with a user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of comment results.</returns>
        Task<ICollection<CommentResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all comments associated with a post asynchronously.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>A collection of comment results.</returns>
        Task<ICollection<CommentResultDTO>> GetAllByPostIdAsync(string postId);

        /// <summary>
        /// Retrieves all comments associated with a comment asynchronously.
        /// </summary>
        /// <param name="commentId">The ID of the comment.</param>
        /// <returns>A collection of comment results.</returns>
        Task<ICollection<CommentResultDTO>> GetAllByIdAsync(string commentId);

        /// <summary>
        /// Adds a new comment asynchronously.
        /// </summary>
        /// <param name="postAddCommentDTO">The data for adding a new comment.</param>
        /// <returns>The result of the comment addition operation.</returns>
        Task<IResult<CommentResultDTO>> AddAsync(CommentAddDTO postAddCommentDTO);

        /// <summary>
        /// Updates an existing comment asynchronously.
        /// </summary>
        /// <param name="id">The ID of the comment to update.</param>
        /// <param name="postUpdateCommentDTO">The data for updating the comment.</param>
        /// <returns>The result of the comment update operation.</returns>
        Task<IResult<CommentResultDTO>> UpdateAsync(string id, CommentUpdateDTO postUpdateCommentDTO);

        /// <summary>
        /// Deletes a comment asynchronously.
        /// </summary>
        /// <param name="id">The ID of the comment to delete.</param>
        /// <returns>The result of the comment deletion operation.</returns>
        Task<IResult<CommentResultDTO>> DeleteAsync(string id);
    }
}