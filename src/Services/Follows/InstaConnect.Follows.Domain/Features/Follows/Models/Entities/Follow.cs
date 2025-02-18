using InstaConnect.Follows.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

public class Follow : BaseEntity
{
    public Follow(string followerId, string followingId)
    {
        FollowerId = followerId;
        FollowingId = followingId;
    }

    public Follow(User follower, User following)
    {
        Follower = follower;
        FollowerId = follower.Id;
        Following = following;
        FollowingId = following.Id;
    }

    public string FollowingId { get; }

    public User? Following { get; }

    public string FollowerId { get; }

    public User? Follower { get; }
}
