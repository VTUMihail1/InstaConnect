namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserDeletedEventRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UserDeletedEventRequest> _objectBuilderFactory = new();

    public UserDeletedEventRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UserDeletedEventRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
