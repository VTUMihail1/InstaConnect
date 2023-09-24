using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Provides methods for managing post likes.
    /// </summary>
    public interface IPostLikeService
    {
        /// <summary>
        /// Gets all post likes asynchronously.
        /// </summary>
        /// <returns>A collection of post like results.</returns>
        Task<ICollection<PostLikeResultDTO>> GetAllAsync();

        /// <summary>
        /// Gets all post likes by a specific user asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A collection of post like results.</returns>
        Task<ICollection<PostLikeResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Gets all post likes for a specific post asynchronously.
        /// </summary>
        /// <param name="postId">The unique identifier of the post.</param>
        /// <returns>A collection of post like results.</returns>
        Task<ICollection<PostLikeResultDTO>> GetAllByPostIdAsync(string postId);

        /// <summary>
        /// Gets a post like by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post like.</param>
        /// <returns>A result containing the post like.</returns>
        Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Gets a post like by user and post identifiers asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="postId">The unique identifier of the post.</param>
        /// <returns>A result containing the post like.</returns>
        Task<IResult<PostLikeResultDTO>> GetByPostIdAndUserIdAsync(string userId, string postId);

        /// <summary>
        /// Adds a new post like asynchronously.
        /// </summary>
        /// <param name="likeAddDTO">The data for creating a new post like.</param>
        /// <returns>A result containing the newly created post like.</returns>
        Task<IResult<PostLikeResultDTO>> AddAsync(PostLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a post like by user and post identifiers asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="postId">The unique identifier of the post.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteByPostIdAndUserIdAsync(string userId, string postId);

        /// <summary>
        /// Deletes a post like by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post like.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteAsync(string id);
    }

}