using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;

namespace InstaConnect.Posts.Data.Features.PostLikes.Abstract;
public interface IPostLikeWriteRepository
{
    void Add(PostLike postLike);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(PostLike postLike);
    Task<PostLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken);
}
