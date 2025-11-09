namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserAddedEventRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UserAddedEventRequest> _objectBuilderFactory = new();

    public UserAddedEventRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UserAddedEventRequestBuilder(objectBuilder);

        return requestBuilder;
    }
}
