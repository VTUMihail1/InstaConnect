using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Read.Data.Abstract;

public interface IPostLikeReadRepository : IBaseReadRepository<PostLike>
{
    Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken);
}
