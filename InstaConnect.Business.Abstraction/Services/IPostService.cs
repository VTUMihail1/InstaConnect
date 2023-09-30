using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing posts.
    /// </summary>
    public interface IPostService
    {
		/// <summary>
		/// Retrieves all posts with pagination based on user criteria.
		/// </summary>
		/// <param name="userId">The ID of the user.</param>
		/// <param name="page">The page number.</param>
		/// <param name="amount">The number of posts to retrieve per page.</param>
		/// <returns>An <see cref="Task"/> representing the asynchronous operation, containing a collection of <see cref="PostResultDTO"/>.</returns>
		Task<ICollection<PostResultDTO>> GetAllAsync(string userId, int page, int amount);

		/// <summary>
		/// Retrieves a post by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the post.</param>
		/// <returns>An <see cref="IResult{T}"/> containing a <see cref="PostResultDTO"/>.</returns>
		Task<IResult<PostResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new post.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="postAddDTO">The data for the new post.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the added <see cref="PostResultDTO"/>.</returns>
        Task<IResult<PostResultDTO>> AddAsync(string currentUserId, PostAddDTO postAddDTO);

        /// <summary>
        /// Updates an existing post by its unique identifier.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="id">The unique identifier of the post to update.</param>
        /// <param name="postUpdateDTO">The data to update the post with.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the updated <see cref="PostResultDTO"/>.</returns>
        Task<IResult<PostResultDTO>> UpdateAsync(string currentUserId, string id, PostUpdateDTO postUpdateDTO);

        /// <summary>
        /// Deletes a post by its unique identifier.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="id">The unique identifier of the post to delete.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="PostResultDTO"/>.</returns>
        Task<IResult<PostResultDTO>> DeleteAsync(string currentUserId, string id);
    }
}