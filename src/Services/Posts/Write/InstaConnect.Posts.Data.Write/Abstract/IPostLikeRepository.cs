using InstaConnect.Posts.Data.Write.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Data.Write.Abstract;

/// <summary>
/// Represents a repository interface specifically for managing post likes, inheriting from the generic repository for entities of type <see cref="PostLike"/>.
/// </summary>
public interface IPostLikeRepository : IBaseRepository<PostLike>
{
    Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken);
}
