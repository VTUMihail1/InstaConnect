using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

public class Follow : IEntity
{
    private Follow()
    {
        FollowerId = string.Empty;
        FollowingId = string.Empty;
    }

    public Follow(
        string followerId,
        string followingId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        FollowerId = followerId;
        FollowingId = followingId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Follow(
        User follower,
        User following,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Follower = follower;
        FollowerId = follower.Id;
        Following = following;
        FollowingId = following.Id;
    }

    public string FollowerId { get; }

    public User? Follower { get; }

    public string FollowingId { get; }

    public User? Following { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}
