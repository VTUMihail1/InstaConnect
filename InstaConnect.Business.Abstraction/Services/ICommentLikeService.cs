using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface ICommentLikeService
    {
        Task<ICollection<CommentLikeResultDTO>> GetAllAsync(string userId, string postCommentId);
        Task<IResult<CommentLikeResultDTO>> GetByIdAsync(string id);
        Task<IResult<CommentLikeResultDTO>> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId);
        Task<IResult<CommentLikeResultDTO>> AddAsync(string currentUserId, CommentLikeAddDTO likeAddDTO);
        Task<IResult<CommentLikeResultDTO>> DeleteByUserIdAndCommentIdAsync(string currentUserId, string userId, string postCommentId);
        Task<IResult<CommentLikeResultDTO>> DeleteAsync(string currentUserId, string id);
    }
}
