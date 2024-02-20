using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing and retrieving follow relationships between users.
    /// </summary>
    public interface IFollowService
    {
        /// <summary>
        /// Asynchronously retrieves a collection of follow relationships based on follower and following user IDs, with pagination support.
        /// </summary>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <param name="followingId">The ID of the following user.</param>
        /// <param name="page">The page number for paginating results.</param>
        /// <param name="amount">The number of follow relationships to retrieve per page.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="ICollection{FollowResultDTO}"/> with the follow relationships.</returns>
        Task<IResult<ICollection<FollowResultDTO>>> GetAllAsync(string followerId, string followingId, int page, int amount);

        /// <summary>
        /// Asynchronously retrieves a follow relationship by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the follow relationship to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="FollowResultDTO"/> with the follow relationship details.</returns>
        Task<IResult<FollowResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Asynchronously retrieves a follow relationship by the follower and following user IDs.
        /// </summary>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <param name="followingId">The ID of the following user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="FollowResultDTO"/> with the follow relationship details.</returns>
        Task<IResult<FollowResultDTO>> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId);

        /// <summary>
        /// Asynchronously adds a new follow relationship between a follower and a following user.
        /// </summary>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <param name="followAddDTO">The data for creating the follow relationship.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="FollowResultDTO"/> with the result of the follow relationship creation.</returns>
        Task<IResult<FollowResultDTO>> AddAsync(string followerId, FollowAddDTO followAddDTO);

        /// <summary>
        /// Asynchronously deletes a follow relationship between a follower and a following user based on their IDs.
        /// </summary>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <param name="followingId">The ID of the following user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="FollowResultDTO"/> with the result of the follow relationship deletion.</returns>
        Task<IResult<FollowResultDTO>> DeleteByFollowerIdAndFollowingIdAsync(string followerId, string followingId);

        /// <summary>
        /// Asynchronously deletes a follow relationship by its unique identifier.
        /// </summary>
        /// <param name="followerId">The ID of the follower user.</param>
        /// <param name="id">The unique identifier of the follow relationship to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="FollowResultDTO"/> with the result of the follow relationship deletion.</returns>
        Task<IResult<FollowResultDTO>> DeleteAsync(string followerId, string id);
    }
}