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
        /// Retrieves all follows with detailed information.
        /// </summary>
        /// <returns>A collection of detailed follow information.</returns>
        Task<ICollection<FollowDetailedDTO>> GetAllDetailedAsync();

        /// <summary>
        /// Retrieves all follows by follower ID with detailed information.
        /// </summary>
        /// <param name="followerId">The follower's ID to filter by.</param>
        /// <returns>A collection of detailed follow information.</returns>
        Task<ICollection<FollowDetailedDTO>> GetAllDetailedByFollowerIdAsync(string followerId);

        /// <summary>
        /// Retrieves all follows by following ID with detailed information.
        /// </summary>
        /// <param name="followingId">The following's ID to filter by.</param>
        /// <returns>A collection of detailed follow information.</returns>
        Task<ICollection<FollowDetailedDTO>> GetAllDetailedByFollowingIdAsync(string followingId);

        /// <summary>
        /// Retrieves a follow by its ID with detailed information.
        /// </summary>
        /// <param name="id">The ID of the follow to retrieve.</param>
        /// <returns>The detailed follow information or a not-found result.</returns>
        Task<IResult<FollowDetailedDTO>> GetDetailedByIdAsync(string id);

        /// <summary>
        /// Retrieves all follows.
        /// </summary>
        /// <returns>A collection of follow information.</returns>
        Task<ICollection<FollowResultDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all follows by follower ID.
        /// </summary>
        /// <param name="followerId">The follower's ID to filter by.</param>
        /// <returns>A collection of follow information.</returns>
        Task<ICollection<FollowResultDTO>> GetAllByFollowerIdAsync(string followerId);

        /// <summary>
        /// Retrieves all follows by following ID.
        /// </summary>
        /// <param name="followingId">The following's ID to filter by.</param>
        /// <returns>A collection of follow information.</returns>
        Task<ICollection<FollowResultDTO>> GetAllByFollowingIdAsync(string followingId);

        /// <summary>
        /// Retrieves a follow by its ID.
        /// </summary>
        /// <param name="id">The ID of the follow to retrieve.</param>
        /// <returns>The follow information or a not-found result.</returns>
        Task<IResult<FollowResultDTO>> GetByIdAsync(string id);

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