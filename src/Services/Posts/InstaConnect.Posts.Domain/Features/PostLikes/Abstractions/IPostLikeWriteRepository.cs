using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
public interface IPostLikeWriteRepository
{
    void Add(PostLike postLike);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(PostLike postLike);
    Task<PostLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken);
}
