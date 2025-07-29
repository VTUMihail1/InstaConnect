using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

public class PostLike : IEntity
{
    private PostLike()
    {
        Id = string.Empty;
        LikeId = string.Empty;
        UserId = string.Empty;
    }

    public PostLike(
        string id,
        string likeId,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        LikeId = likeId;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostLike(
        string id,
        string likeId,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        LikeId = likeId;
        User = user;
        UserId = user.Id;
    }

    public string Id { get; }

    public string LikeId { get; }

    public string UserId { get; }

    public User? User { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}
