using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Posts.Data.Features.PostLikes.Abstract;

public interface IPostLikeWriteRepository : IBaseWriteRepository<PostLike>
{
    Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken);
}
