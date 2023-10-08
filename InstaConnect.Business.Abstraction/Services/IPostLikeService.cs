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
        /// Retrieves all post comments with pagination support based on user ID and post ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="postId">The ID of the post.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="amount">The number of post comments to retrieve per page.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a collection of <see cref="PostLikeResultDTO"/>.</returns>
        Task<IResult<ICollection<PostLikeResultDTO>>> GetAllAsync(string userId, string postId, int page, int amount);

        /// <summary>
        /// Retrieves a post like by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post like.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="PostLikeResultDTO"/>.</returns>
        Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Retrieves a post like by user ID and post ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="PostLikeResultDTO"/>.</returns>
        Task<IResult<PostLikeResultDTO>> GetByUserIdAndPostIdAsync(string userId, string postId);

        /// <summary>
        /// Adds a new post like.
        /// </summary>
        /// <param name="likeAddDTO">The data for the new post like.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the added <see cref="PostLikeResultDTO"/>.</returns>
        Task<IResult<PostLikeResultDTO>> AddAsync(PostLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a post like by user ID and post ID.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="PostLikeResultDTO"/>.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteByUserIdAndPostIdAsync(string userId, string postId);

        /// <summary>
        /// Deletes a post like by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the current user performing the action.</param>
        /// <param name="id">The unique identifier of the post like to delete.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="PostLikeResultDTO"/>.</returns>
        Task<IResult<PostLikeResultDTO>> DeleteAsync(string userId, string id);
    }
}