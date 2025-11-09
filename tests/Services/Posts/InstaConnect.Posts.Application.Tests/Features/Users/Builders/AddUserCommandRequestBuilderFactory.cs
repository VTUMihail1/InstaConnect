namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class AddUserCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddUserCommandRequest> _objectBuilderFactory = new();

    public AddUserCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddUserCommandRequestBuilder(objectBuilder);

        return requestBuilder;
    }
}
