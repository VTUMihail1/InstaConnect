namespace InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

public class Follow : IEntity<FollowId>
{
    private Follow()
    {
        Id = new(new(string.Empty), new(string.Empty));
    }

    public Follow(
        FollowId followId,
        DateTimeOffset createdAtUtc)
    {
        Id = followId;
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
