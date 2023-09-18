using InstaConnect.Business.Models.DTOs.Like;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing likes on posts.
    /// </summary>
    public interface ILikeService
    {
        /// <summary>
        /// Retrieves all likes associated with a user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of like results.</returns>
        Task<ICollection<LikeResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all likes associated with a post asynchronously.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>A collection of like results.</returns>
        Task<ICollection<LikeResultDTO>> GetAllByPostIdAsync(string postId);

        /// <summary>
        /// Adds a new like asynchronously.
        /// </summary>
        /// <param name="likeAddDTO">The data for adding a new like.</param>
        /// <returns>The result of the like addition operation.</returns>
        Task<IResult<LikeResultDTO>> AddAsync(LikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a like asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="postId">The ID of the post that was liked.</param>
        /// <returns>The result of the like deletion operation.</returns>
        Task<IResult<LikeResultDTO>> DeleteAsync(string userId, string postId);
    }
}