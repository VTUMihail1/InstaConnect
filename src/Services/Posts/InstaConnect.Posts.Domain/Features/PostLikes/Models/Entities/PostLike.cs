using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

public class PostLike : IEntity
{
    private PostLike()
    {
        Id = string.Empty;
        UserId = string.Empty;
    }

    public PostLike(
        string id,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostLike(
        string id,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        User = user;
        UserId = user.Id;
    }

    public string Id { get; }

    public string UserId { get; }

    public User? User { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}
