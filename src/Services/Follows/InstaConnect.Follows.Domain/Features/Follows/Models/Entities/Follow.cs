using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Domain.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

public class Follow : IBaseEntity, IAuditableInfo
{
    private Follow()
    {
        Id = string.Empty;
        FollowerId = string.Empty;
        FollowingId = string.Empty;
    }

    public Follow(
        string id,
        string followerId,
        string followingId,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        FollowerId = followerId;
        FollowingId = followingId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Follow(
        string id,
        User follower,
        User following,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Follower = follower;
        FollowerId = follower.Id;
        Following = following;
        FollowingId = following.Id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string FollowingId { get; }

    public User? Following { get; }

    public string FollowerId { get; }

    public User? Follower { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }
}
