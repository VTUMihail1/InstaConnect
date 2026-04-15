namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class AddFollowCommandRequestBuilderFactory
{
    public AddFollowCommandRequestBuilder Create(User follower, User following)
    {
        return new(follower, following);
    }
}
