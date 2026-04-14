namespace InstaConnect.Follows.Tests.Features.Follows.Builders;

public class FollowBuilderFactory
{
    public FollowBuilder Create(User follower, User following)
    {
        return new(follower, following);
    }
}
