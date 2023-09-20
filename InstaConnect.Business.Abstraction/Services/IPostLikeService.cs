using InstaConnect.Business.Models.DTOs.Like;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing post likes.
    /// </summary>
    public interface IPostLikeService
    {
        /// <summary>
        /// Retrieves all post like associated with a user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of post like results.</returns>
        Task<ICollection<PostLikeResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all post like associated with a post asynchronously.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>A collection of post like results.</returns>
        Task<ICollection<PostLikeResultDTO>> GetAllByPostIdAsync(string postId);

        /// <summary>
        /// Adds a new post like asynchronously.
        /// </summary>
        /// <param name="likeAddDTO">The data for adding a new post like.</param>
        /// <returns>The result of the post like addition operation.</returns>
        Task<IResult<PostLikeResultDTO>> AddAsync(PostLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a post like asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="postId">The ID of the post that was liked.</param>
        /// <returns>The result of the post like deletion operation.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteAsync(string userId, string postId);
    }
}