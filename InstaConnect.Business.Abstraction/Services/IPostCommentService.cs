using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing comments.
    /// </summary>
    public interface IPostCommentService
    {
        /// <summary>
        /// Retrieves all post comments, including detailed information.
        /// </summary>
        /// <returns>A collection of detailed post comments.</returns>
        Task<ICollection<PostCommentDetailedDTO>> GetAllDetailedAsync();

        /// <summary>
        /// Retrieves all post comments by user ID, including detailed information.
        /// </summary>
        /// <param name="userId">The user ID to filter by.</param>
        /// <returns>A collection of detailed post comments.</returns>
        Task<ICollection<PostCommentDetailedDTO>> GetAllDetailedByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all post comments by post ID, including detailed information.
        /// </summary>
        /// <param name="postId">The post ID to filter by.</param>
        /// <returns>A collection of detailed post comments.</returns>
        Task<ICollection<PostCommentDetailedDTO>> GetAllDetailedByPostIdAsync(string postId);

        /// <summary>
        /// Retrieves all post comments by parent comment ID, including detailed information.
        /// </summary>
        /// <param name="postCommentId">The parent comment ID to filter by.</param>
        /// <returns>A collection of detailed post comments.</returns>
        Task<ICollection<PostCommentDetailedDTO>> GetAllDetailedByParentIdAsync(string postCommentId);

        /// <summary>
        /// Retrieves a detailed post comment by its ID.
        /// </summary>
        /// <param name="id">The ID of the post comment to retrieve.</param>
        /// <returns>The detailed post comment or a not-found result.</returns>
        Task<IResult<PostCommentDetailedDTO>> GetDetailedByIdAsync(string id);

        /// <summary>
        /// Retrieves all post comments, including basic information.
        /// </summary>
        /// <returns>A collection of post comments.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all post comments by user ID.
        /// </summary>
        /// <param name="userId">The user ID to filter by.</param>
        /// <returns>A collection of post comments.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all post comments by post ID.
        /// </summary>
        /// <param name="postId">The post ID to filter by.</param>
        /// <returns>A collection of post comments.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByPostIdAsync(string postId);

        /// <summary>
        /// Retrieves all post comments by parent comment ID.
        /// </summary>
        /// <param name="postCommentId">The parent comment ID to filter by.</param>
        /// <returns>A collection of post comments.</returns>
        Task<ICollection<PostCommentResultDTO>> GetAllByParentIdAsync(string postCommentId);

        /// <summary>
        /// Retrieves a post comment by its ID.
        /// </summary>
        /// <param name="id">The ID of the post comment to retrieve.</param>
        /// <returns>The post comment or a not-found result.</returns>
        Task<IResult<PostCommentResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new post comment asynchronously.
        /// </summary>
        /// <param name="postCommentAddDTO">The data for adding a new post comment.</param>
        /// <returns>The result of the post comment addition operation.</returns>
        Task<IResult<PostCommentResultDTO>> AddAsync(PostCommentAddDTO postCommentAddDTO);

        /// <summary>
        /// Updates an existing post comment asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post comment to update.</param>
        /// <param name="postCommentUpdateDTO">The data for updating the post comment.</param>
        /// <returns>The result of the post comment update operation.</returns>
        Task<IResult<PostCommentResultDTO>> UpdateAsync(string id, PostCommentUpdateDTO postCommentUpdateDTO);

        /// <summary>
        /// Deletes a post comment asynchronously.
        /// </summary>
        /// <param name="id">The ID of the post comment to delete.</param>
        /// <returns>The result of the post comment deletion operation.</returns>
        Task<IResult<PostCommentResultDTO>> DeleteAsync(string id);
    }
}