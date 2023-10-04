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
        /// Retrieves all follows with pagination support based on follower and following user IDs.
        /// </summary>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <param name="followingId">The ID of the following user.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="amount">The number of follows to retrieve per page.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a collection of <see cref="FollowResultDTO"/>.</returns>
        Task<IResult<ICollection<FollowResultDTO>>> GetAllAsync(string followerId, string followingId, int page, int amount);

        /// <summary>
        /// Retrieves a follow by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the follow.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="FollowResultDTO"/>.</returns>
        Task<IResult<FollowResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Retrieves a follow by follower ID and following ID.
        /// </summary>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <param name="followingId">The ID of the following user.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="FollowResultDTO"/>.</returns>
        Task<IResult<FollowResultDTO>> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId);

        /// <summary>
        /// Adds a new follow.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="followAddDTO">The data for the new follow.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the added <see cref="FollowResultDTO"/>.</returns>
        Task<IResult<FollowResultDTO>> AddAsync(string currentUserId, FollowAddDTO followAddDTO);

        /// <summary>
        /// Deletes a follow by follower ID and following ID.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <param name="followingId">The ID of the following user.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="FollowResultDTO"/>.</returns>
        Task<IResult<FollowResultDTO>> DeleteByFollowerIdAndFollowingIdAsync(string currentUserId, string followerId, string followingId);

        /// <summary>
        /// Deletes a follow by its unique identifier.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="id">The unique identifier of the follow to delete.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="FollowResultDTO"/>.</returns>
        Task<IResult<FollowResultDTO>> DeleteAsync(string currentUserId, string id);
    }
}