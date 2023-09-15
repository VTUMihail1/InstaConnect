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
        /// Adds a new post asynchronously.
        /// </summary>
        /// <param name="postAddDTO">The post data to be added.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> AddAsync(PostAddDTO postAddDTO);

        /// <summary>
        /// Deletes a post asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to be deleted.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> DeleteAsync(string id);

        /// <summary>
        /// Retrieves all posts asynchronously.
        /// </summary>
        /// <returns>An asynchronous task that returns a collection of post results.</returns>
        Task<ICollection<PostResultDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all posts associated with a specific user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An asynchronous task that returns a collection of post results.</returns>
        Task<ICollection<PostResultDTO>> GetAllByUserId(string userId);

        /// <summary>
        /// Retrieves a post by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Updates a post asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to be updated.</param>
        /// <param name="postUpdateDTO">The post data to be updated.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> UpdateAsync(string id, PostUpdateDTO postUpdateDTO);
    }
}