using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories.Abstract;

namespace InstaConnect.Posts.Data.Abstract.Repositories;

/// <summary>
/// Represents a repository interface specifically for managing post comment likes, inheriting from the generic repository for entities of type <see cref="PostCommentLike"/>.
/// </summary>
public interface IPostCommentLikeRepository : IBaseRepository<PostCommentLike>
{
    Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken);
}
