using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Read.Data.Abstract;

/// <summary>
/// Represents a repository interface specifically for managing post likes, inheriting from the generic repository for entities of type <see cref="PostLike"/>.
/// </summary>
public interface IPostLikeRepository : IBaseReadRepository<PostLike>
{
    Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken);
}
