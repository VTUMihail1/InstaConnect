using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing post likes.
    /// </summary>
    public interface IPostLikeService
    {
        /// <summary>
        /// Retrieves all post likes with detailed information.
        /// </summary>
        /// <returns>A collection of detailed post like information.</returns>
        Task<ICollection<PostLikeDetailedDTO>> GetAllDetailedAsync();

        /// <summary>
        /// Retrieves all post likes by user ID with detailed information.
        /// </summary>
        /// <param name="userId">The user's ID to filter by.</param>
        /// <returns>A collection of detailed post like information.</returns>
        Task<ICollection<PostLikeDetailedDTO>> GetAllDetailedByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all post likes by post ID with detailed information.
        /// </summary>
        /// <param name="postId">The post's ID to filter by.</param>
        /// <returns>A collection of detailed post like information.</returns>
        Task<ICollection<PostLikeDetailedDTO>> GetAllDetailedByPostIdAsync(string postId);

        /// <summary>
        /// Retrieves a post like by its ID with detailed information.
        /// </summary>
        /// <param name="id">The ID of the post like to retrieve.</param>
        /// <returns>The detailed post like information or a not-found result.</returns>
        Task<IResult<PostLikeDetailedDTO>> GetDetailedByIdAsync(string id);

        /// <summary>
        /// Retrieves all post likes.
        /// </summary>
        /// <returns>A collection of post like information.</returns>
        Task<ICollection<PostLikeResultDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all post likes by user ID.
        /// </summary>
        /// <param name="userId">The user's ID to filter by.</param>
        /// <returns>A collection of post like information.</returns>
        Task<ICollection<PostLikeResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all post likes by post ID.
        /// </summary>
        /// <param name="postId">The post's ID to filter by.</param>
        /// <returns>A collection of post like information.</returns>
        Task<ICollection<PostLikeResultDTO>> GetAllByPostIdAsync(string postId);

        /// <summary>
        /// Retrieves a post like by its ID.
        /// </summary>
        /// <param name="id">The ID of the post like to retrieve.</param>
        /// <returns>The post like information or a not-found result.</returns>
        Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new post like asynchronously.
        /// </summary>
        /// <param name="likeAddDTO">The data for adding a new post like.</param>
        /// <returns>The result of the post like addition operation.</returns>
        Task<IResult<PostLikeResultDTO>> AddAsync(PostLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a post like asynchronously based on the post ID and user ID.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="postId">The ID of the post for which the like will be deleted.</param>
        /// <returns>The result of the post like deletion operation.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteByPostIdAndUserIdAsync(string userId, string postId);

        /// <summary>
        /// Deletes a post like asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post like to delete.</param>
        /// <returns>The result of the post like deletion operation.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteAsync(string id);
    }
}