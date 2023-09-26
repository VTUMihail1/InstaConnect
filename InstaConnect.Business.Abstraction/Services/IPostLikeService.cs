using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface IPostLikeService
    {
        Task<ICollection<PostLikeResultDTO>> GetAllAsync(string userId, string postId);
        Task<IResult<PostLikeResultDTO>> GetByIdAsync(string id);
        Task<IResult<PostLikeResultDTO>> GetByUserIdAndPostIdAsync(string userId, string postId);
        Task<IResult<PostLikeResultDTO>> AddAsync(string currentUserId, PostLikeAddDTO likeAddDTO);
        Task<IResult<PostLikeResultDTO>> DeleteByUserIdAndPostIdAsync(string currentUserId, string userId, string postId);
        Task<IResult<PostLikeResultDTO>> DeleteAsync(string currentUserId, string id);
    }

}