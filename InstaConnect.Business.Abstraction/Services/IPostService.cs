using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Provides methods for managing posts.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Retrieves a collection of PostResultDTO representing the posts associated with a user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom posts are being retrieved.</param>
        /// <returns>A Task representing the asynchronous operation that returns an ICollection of PostResultDTO.</returns>
        Task<ICollection<PostResultDTO>> GetAllAsync(string userId);

        /// <summary>
        /// Gets a post by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post.</param>
        /// <returns>A result containing the post.</returns>
        Task<IResult<PostResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new post asynchronously.
        /// </summary>
        /// <param name="postAddDTO">The data for creating a new post.</param>
        /// <returns>A result containing the newly created post.</returns>
        Task<IResult<PostResultDTO>> AddAsync(PostAddDTO postAddDTO);

        /// <summary>
        /// Updates a post by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post.</param>
        /// <param name="postUpdateDTO">The data for updating the post.</param>
        /// <returns>A result containing the updated post.</returns>
        Task<IResult<PostResultDTO>> UpdateAsync(string id, PostUpdateDTO postUpdateDTO);

        /// <summary>
        /// Deletes a post by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<PostResultDTO>> DeleteAsync(string id);
    }
}