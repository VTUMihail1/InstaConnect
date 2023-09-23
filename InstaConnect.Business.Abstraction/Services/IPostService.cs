﻿using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing posts.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Retrieves all posts in a detailed format asynchronously.
        /// </summary>
        /// <returns>A collection of detailed post results.</returns>
        Task<ICollection<PostDetailedDTO>> GetAllDetailedAsync();

        /// <summary>
        /// Retrieves all posts asynchronously.
        /// </summary>
        /// <returns>A collection of post results.</returns>
        Task<ICollection<PostResultDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all posts associated with a user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of post results.</returns>
        Task<ICollection<PostResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves a post by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <returns>The result of the post retrieval operation.</returns>
        Task<IResult<PostResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new post asynchronously.
        /// </summary>
        /// <param name="postAddDTO">The data for adding a new post.</param>
        /// <returns>The result of the post addition operation.</returns>
        Task<IResult<PostResultDTO>> AddAsync(PostAddDTO postAddDTO);

        /// <summary>
        /// Updates an existing post asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post to update.</param>
        /// <param name="postUpdateDTO">The data for updating the post.</param>
        /// <returns>The result of the post update operation.</returns>
        Task<IResult<PostResultDTO>> UpdateAsync(string id, PostUpdateDTO postUpdateDTO);

        /// <summary>
        /// Deletes a post asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <returns>The result of the post deletion operation.</returns>
        Task<IResult<PostResultDTO>> DeleteAsync(string id);
    }

}