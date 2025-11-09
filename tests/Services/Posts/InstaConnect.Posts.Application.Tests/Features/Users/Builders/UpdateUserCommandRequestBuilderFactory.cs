namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class UpdateUserCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdateUserCommandRequest> _objectBuilderFactory = new();

    public UpdateUserCommandRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdateUserCommandRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
