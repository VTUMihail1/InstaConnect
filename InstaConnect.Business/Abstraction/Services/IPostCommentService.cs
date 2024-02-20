using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing and retrieving post comments.
    /// </summary>
    public interface IPostCommentService
    {
        /// <summary>
        /// Asynchronously retrieves a collection of post comments associated with a user, post, and post comment ID, with pagination support.
        /// </summary>
        /// <param name="userId">The ID of the user who made the post comment.</param>
        /// <param name="postId">The ID of the post to which the comment is associated.</param>
        /// <param name="postCommentId">The ID of the specific post comment, or null to fetch all comments for the post.</param>
        /// <param name="page">The page number for paginating results.</param>
        /// <param name="amount">The number of post comments to retrieve per page.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="ICollection{PostCommentResultDTO}"/> with the post comments.</returns>
        Task<IResult<ICollection<PostCommentResultDTO>>> GetAllAsync(string userId, string postId, string postCommentId, int page, int amount);

        /// <summary>
        /// Asynchronously retrieves a post comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post comment to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentResultDTO"/> with the post comment details.</returns>
        Task<IResult<PostCommentResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Asynchronously adds a new post comment to a post by the user.
        /// </summary>
        /// <param name="userId">The ID of the user who is making the comment.</param>
        /// <param name="postCommentAddDTO">The data for creating the post comment.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentResultDTO"/> with the result of the comment creation.</returns>
        Task<IResult<PostCommentResultDTO>> AddAsync(string userId, PostCommentAddDTO postCommentAddDTO);

        /// <summary>
        /// Asynchronously updates a post comment made by the user, based on the comment's unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user who made the comment.</param>
        /// <param name="id">The unique identifier of the post comment to update.</param>
        /// <param name="postCommentUpdateDTO">The data for updating the post comment.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentResultDTO"/> with the result of the comment update.</returns>
        Task<IResult<PostCommentResultDTO>> UpdateAsync(string userId, string id, PostCommentUpdateDTO postCommentUpdateDTO);

        /// <summary>
        /// Asynchronously deletes a post comment made by the user, based on the comment's unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user who made the comment.</param>
        /// <param name="id">The unique identifier of the post comment to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentResultDTO"/> with the result of the comment deletion.</returns>
        Task<IResult<PostCommentResultDTO>> DeleteAsync(string userId, string id);
    }
}