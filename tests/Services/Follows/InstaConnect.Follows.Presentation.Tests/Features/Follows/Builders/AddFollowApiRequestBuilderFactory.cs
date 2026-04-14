namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class AddFollowApiRequestBuilderFactory
{
    public AddFollowApiRequestBuilder Create(User follower, User following)
    {
        return new(follower, following);
    }
}
