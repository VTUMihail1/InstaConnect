using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing comment likes.
    /// </summary>
    public interface ICommentLikeService
    {
        /// <summary>
        /// Retrieves all comment likes associated with a user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of comment like results.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves all comment likes associated with a comment asynchronously.
        /// </summary>
        /// <param name="commentId">The ID of the comment.</param>
        /// <returns>A collection of comment like results.</returns>
        Task<ICollection<CommentLikeResultDTO>> GetAllByCommentIdAsync(string commentId);

        /// <summary>
        /// Adds a new comment like asynchronously.
        /// </summary>
        /// <param name="likeAddDTO">The data for adding a new comment like.</param>
        /// <returns>The result of the comment like addition operation.</returns>
        Task<IResult<CommentLikeResultDTO>> AddAsync(CommentLikeAddDTO likeAddDTO);

        /// <summary>
        /// Deletes a comment like asynchronously.
        /// </summary>
        /// <param name="id">The ID of the comment like to delete.</param>
        /// <returns>The result of the comment like deletion operation.</returns>
        Task<IResult<CommentLikeResultDTO>> DeleteAsync(string id);
    }
}
