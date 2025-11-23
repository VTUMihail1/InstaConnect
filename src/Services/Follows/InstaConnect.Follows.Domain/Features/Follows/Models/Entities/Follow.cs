namespace InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

public class Follow : IEntity<FollowId>
{
    private Follow()
    {
        Id = new(new(string.Empty), new(string.Empty));
    }

    public Follow(
        FollowId followId,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = followId;
        CreatedAtUtc = createdAtUtc;
    }

    public Follow(
        FollowId followId,
        User follower,
        User following,
        DateTimeOffset createdAtUtc)
    {
        Id = followId;
        Follower = follower;
        Following = following;
        CreatedAtUtc = createdAtUtc;
    }

    public FollowId Id { get; }

    public User? Follower { get; private set; }

    public User? Following { get; private set; }

    public DateTimeOffset CreatedAtUtc { get; }

    public void AddFollower(User follower)
    {
        Follower = follower;
    }

    public void AddFollowing(User following)
    {
        Following = following;
    }
}
