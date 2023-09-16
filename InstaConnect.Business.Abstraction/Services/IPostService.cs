using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Results;
using System.ComponentModel.Design;

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

        /// <summary>
        /// Adds a like to a post asynchronously.
        /// </summary>
        /// <param name="postAddLikeDTO">The data for adding a like to a post.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> AddPostLikeAsync(PostAddLikeDTO postAddLikeDTO);

        /// <summary>
        /// Deletes a like from a post asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user whose like is to be removed.</param>
        /// <param name="postId">The ID of the post from which the like is to be removed.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> DeletePostLikeAsync(string userId, string postId);

        /// <summary>
        /// Adds a comment to a post asynchronously.
        /// </summary>
        /// <param name="postAddCommentDTO">The data for adding a comment to a post.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> AddPostCommentAsync(PostAddCommentDTO postAddCommentDTO);

        /// <summary>
        /// Updates a comment on a post asynchronously.
        /// </summary>
        /// <param name="commentId">The ID of the comment to be updated.</param>
        /// <param name="postUpdateCommentDTO">The data for updating the comment.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> UpdatePostCommentAsync(string commentId, PostUpdateCommentDTO postUpdateCommentDTO);

        /// <summary>
        /// Deletes a comment from a post asynchronously.
        /// </summary>
        /// <param name="commentId">The ID of the comment to be deleted.</param>
        /// <returns>An asynchronous task that returns the result of the operation.</returns>
        Task<IResult<PostResultDTO>> DeletePostCommentAsync(string commentId);
    }
}