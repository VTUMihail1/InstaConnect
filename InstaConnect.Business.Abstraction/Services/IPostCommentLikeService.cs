using InstaConnect.Business.Models.DTOs.PostCommentLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing and retrieving likes on post comments.
    /// </summary>
    public interface IPostCommentLikeService
    {
        /// <summary>
        /// Asynchronously retrieves a collection of post comment likes given a user ID, post comment ID, and supports pagination.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post comment.</param>
        /// <param name="postCommentId">The ID of the post comment that received the likes.</param>
        /// <param name="page">The page number for paginating results.</param>
        /// <param name="amount">The number of post comment likes to retrieve per page.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="ICollection{PostCommentLikeResultDTO}"/> with the post comment likes.</returns>
        Task<IResult<ICollection<PostCommentLikeResultDTO>>> GetAllAsync(string userId, string postCommentId, int page, int amount);

        /// <summary>
        /// Asynchronously retrieves a post comment like by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post comment like to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentLikeResultDTO"/> with the post comment like details.</returns>
        Task<IResult<PostCommentLikeResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Asynchronously retrieves a post comment like by user ID and post comment ID.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post comment.</param>
        /// <param name="postCommentId">The ID of the post comment that received the like.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentLikeResultDTO"/> with the post comment like details.</returns>
        Task<IResult<PostCommentLikeResultDTO>> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId);

        /// <summary>
        /// Asynchronously adds a new like to a post comment by the user.
        /// </summary>
        /// <param name="userId">The ID of the user who is liking the post comment.</param>
        /// <param name="postLikeAddDTO">The data for creating the post comment like.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentLikeResultDTO"/> with the result of the like creation.</returns>
        Task<IResult<PostCommentLikeResultDTO>> AddAsync(string userId, PostCommentLikeAddDTO postLikeAddDTO);

        /// <summary>
        /// Asynchronously deletes a post comment like based on the user ID and post comment ID.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post comment.</param>
        /// <param name="postCommentId">The ID of the post comment that was liked.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentLikeResultDTO"/> with the result of the like deletion.</returns>
        Task<IResult<PostCommentLikeResultDTO>> DeleteByUserIdAndPostCommentIdAsync(string userId, string postCommentId);

        /// <summary>
        /// Asynchronously deletes a post comment like by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post comment.</param>
        /// <param name="id">The unique identifier of the post comment like to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostCommentLikeResultDTO"/> with the result of the like deletion.</returns>
        Task<IResult<PostCommentLikeResultDTO>> DeleteAsync(string userId, string id);
    }
}
