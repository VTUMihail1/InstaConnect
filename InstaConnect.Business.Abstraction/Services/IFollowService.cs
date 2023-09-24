using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Provides methods for managing user follow relationships.
    /// </summary>
    public interface IFollowService
    {
        /// <summary>
        /// Gets all user follows asynchronously.
        /// </summary>
        /// <returns>A collection of follow results.</returns>
        Task<ICollection<FollowResultDTO>> GetAllAsync();

        /// <summary>
        /// Gets all user follows for a specific follower asynchronously.
        /// </summary>
        /// <param name="followerId">The unique identifier of the follower user.</param>
        /// <returns>A collection of follow results.</returns>
        Task<ICollection<FollowResultDTO>> GetAllByFollowerIdAsync(string followerId);

        /// <summary>
        /// Gets all user follows for a specific following user asynchronously.
        /// </summary>
        /// <param name="followingId">The unique identifier of the following user.</param>
        /// <returns>A collection of follow results.</returns>
        Task<ICollection<FollowResultDTO>> GetAllByFollowingIdAsync(string followingId);

        /// <summary>
        /// Gets a follow relationship by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the follow relationship.</param>
        /// <returns>A result containing the follow relationship.</returns>
        Task<IResult<FollowResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Gets a follow relationship by follower and following user identifiers asynchronously.
        /// </summary>
        /// <param name="followerId">The unique identifier of the follower user.</param>
        /// <param name="followingId">The unique identifier of the following user.</param>
        /// <returns>A result containing the follow relationship.</returns>
        Task<IResult<FollowResultDTO>> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId);

        /// <summary>
        /// Adds a new follow relationship asynchronously.
        /// </summary>
        /// <param name="followAddDTO">The data for creating a new follow relationship.</param>
        /// <returns>A result containing the newly created follow relationship.</returns>
        Task<IResult<FollowResultDTO>> AddAsync(FollowAddDTO followAddDTO);

        /// <summary>
        /// Deletes a follow relationship by follower and following user identifiers asynchronously.
        /// </summary>
        /// <param name="followingId">The unique identifier of the following user.</param>
        /// <param name="followerId">The unique identifier of the follower user.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<FollowResultDTO>> DeleteByFollowerIdAndFollowingIdAsync(string followingId, string followerId);

        /// <summary>
        /// Deletes a follow relationship by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the follow relationship.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<FollowResultDTO>> DeleteAsync(string id);
    }

}