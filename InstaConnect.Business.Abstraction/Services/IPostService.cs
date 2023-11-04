using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing and retrieving posts.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Asynchronously retrieves a collection of posts associated with a user, with pagination support.
        /// </summary>
        /// <param name="userId">The ID of the user who created the posts.</param>
        /// <param name="page">The page number for paginating results.</param>
        /// <param name="amount">The number of posts to retrieve per page.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="ICollection{PostResultDTO}"/> with the posts.</returns>
        Task<IResult<ICollection<PostResultDTO>>> GetAllAsync(string userId, int page, int amount);

        /// <summary>
        /// Asynchronously retrieves a post by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostResultDTO"/> with the post details.</returns>
        Task<IResult<PostResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Asynchronously adds a new post to the system created by the user.
        /// </summary>
        /// <param name="userId">The ID of the user who is creating the post.</param>
        /// <param name="postAddDTO">The data for creating the post.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostResultDTO"/> with the result of the post creation.</returns>
        Task<IResult<PostResultDTO>> AddAsync(string userId, PostAddDTO postAddDTO);

        /// <summary>
        /// Asynchronously updates a post created by the user, based on the post's unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user who created the post.</param>
        /// <param name="id">The unique identifier of the post to update.</param>
        /// <param name="postUpdateDTO">The data for updating the post.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostResultDTO"/> with the result of the post update.</returns>
        Task<IResult<PostResultDTO>> UpdateAsync(string userId, string id, PostUpdateDTO postUpdateDTO);

        /// <summary>
        /// Asynchronously deletes a post created by the user, based on the post's unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user who created the post.</param>
        /// <param name="id">The unique identifier of the post to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="PostResultDTO"/> with the result of the post deletion.</returns>
        Task<IResult<PostResultDTO>> DeleteAsync(string userId, string id);
    }
}