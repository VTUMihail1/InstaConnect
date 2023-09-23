using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing user follows.
    /// </summary>
    public interface IFollowService
    {
        /// <summary>
        /// Retrieves all user follows based on the follower's ID asynchronously.
        /// </summary>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <returns>A collection of follow results.</returns>
        Task<ICollection<FollowResultDTO>> GetAllByFollowerIdAsync(string followerId);

        /// <summary>
        /// Retrieves all user follows based on the following user's ID asynchronously.
        /// </summary>
        /// <param name="followingId">The ID of the following user.</param>
        /// <returns>A collection of follow results.</returns>
        Task<ICollection<FollowResultDTO>> GetAllByFollowingIdAsync(string followingId);

        /// <summary>
        /// Adds a new follow relationship asynchronously.
        /// </summary>
        /// <param name="followAddDTO">The data for adding a new follow relationship.</param>
        /// <returns>The result of the follow addition operation.</returns>
        Task<IResult<FollowResultDTO>> AddAsync(FollowAddDTO followAddDTO);

        /// <summary>
        /// Deletes a follow relationship asynchronously between a follower and the user being followed.
        /// </summary>
        /// <param name="followingId">The ID of the user being followed.</param>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <returns>The result of the follow relationship deletion operation.</returns>
        Task<IResult<FollowResultDTO>> DeleteByFollowerIdAndFollowingIdAsync(string followingId, string followerId);

        /// <summary>
        /// Deletes a follow asynchronously.
        /// </summary>
        /// <param name="id">The ID of the follow to delete.</param>
        /// <returns>The result of the follow deletion operation.</returns>
        Task<IResult<FollowResultDTO>> DeleteAsync(string id);
    }
}