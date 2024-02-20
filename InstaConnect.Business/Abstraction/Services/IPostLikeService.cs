using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing and retrieving likes on posts.
    /// </summary>
    public interface IPostLikeService
    {
        /// <summary>
        /// Asynchronously retrieves a collection of post likes associated with a user, post, and supports pagination.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="postId">The ID of the post that received the likes.</param>
        /// <param name="page">The page number for paginating results.</param>
        /// <param name="amount">The number of post likes to retrieve per page.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="ICollection{PostLikeResultDTO}"/> with the post likes.</returns>
        Task<IResult<ICollection<PostLikeResultDTO>>> GetAllAsync(string userId, string postId, int page, int amount);

        /// <summary>
        /// Asynchronously retrieves a post like by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post like to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostLikeResultDTO"/> with the post like details.</returns>
        Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Asynchronously retrieves a post like by user ID and post ID.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="postId">The ID of the post that was liked.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostLikeResultDTO"/> with the post like details.</returns>
        Task<IResult<PostLikeResultDTO>> GetByUserIdAndPostIdAsync(string userId, string postId);

        /// <summary>
        /// Asynchronously adds a new like to a post by the user.
        /// </summary>
        /// <param name="userId">The ID of the user who is liking the post.</param>
        /// <param name="likeAddDTO">The data for creating the post like.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostLikeResultDTO"/> with the result of the like creation.</returns>
        Task<IResult<PostLikeResultDTO>> AddAsync(string userId, PostLikeAddDTO likeAddDTO);

        /// <summary>
        /// Asynchronously deletes a post like based on the user ID and post ID.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="postId">The ID of the post that was liked.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostLikeResultDTO"/> with the result of the like deletion.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteByUserIdAndPostIdAsync(string userId, string postId);

        /// <summary>
        /// Asynchronously deletes a post like by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="id">The unique identifier of the post like to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostLikeResultDTO"/> with the result of the like deletion.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteAsync(string userId, string id);
    }
}