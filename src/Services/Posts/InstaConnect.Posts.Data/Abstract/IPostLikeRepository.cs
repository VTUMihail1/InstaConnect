using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories.Abstract;

namespace InstaConnect.Posts.Data.Abstract;

/// <summary>
/// Represents a repository interface specifically for managing post likes, inheriting from the generic repository for entities of type <see cref="PostLike"/>.
/// </summary>
public interface IPostLikeRepository : IBaseRepository<PostLike>
{
    Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken);
}
