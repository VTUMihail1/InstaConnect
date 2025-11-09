namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class DeleteUserCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeleteUserCommandRequest> _objectBuilderFactory = new();

    public DeleteUserCommandRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeleteUserCommandRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
