namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserUpdatedEventRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UserUpdatedEventRequest> _objectBuilderFactory = new();

    public UserUpdatedEventRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UserUpdatedEventRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
