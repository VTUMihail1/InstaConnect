namespace InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

public class Follow : IEntityWithId<FollowId>
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

    public Follow AddFollower(User? follower)
    {
        Follower = follower;

        return this;
    }

    public Follow AddFollowing(User? following)
    {
        Following = following;

        return this;
    }
}
