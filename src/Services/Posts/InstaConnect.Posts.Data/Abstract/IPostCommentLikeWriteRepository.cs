using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Write.Data.Abstract;

public interface IPostCommentLikeWriteRepository : IBaseWriteRepository<PostCommentLike>
{
    Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken);
}
