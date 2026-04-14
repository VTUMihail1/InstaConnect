using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Builders;

public class FollowBuilder
{
    private string _followerId;
    private User _follower;
    private string _followingId;
    private User _following;
    private DateTimeOffset _createdAtUtc;

    public FollowBuilder(User follower, User following)
    {
        _followerId = follower.Id.Id;
        _follower = follower;
        _followingId = following.Id.Id;
        _following = following;
        _createdAtUtc = FollowDataFaker.GetCreatedAtUtc();
    }

    public Follow Build()
    {
        var follow = new Follow(
                new(
                    new(_followerId),
                    new(_followingId)),
                _createdAtUtc);

        _follower.AddFollowFollowing(follow);
        _following.AddFollowFollower(follow);
        follow.AddFollower(_follower);
        follow.AddFollowing(_following);

        return follow;
    }
}
