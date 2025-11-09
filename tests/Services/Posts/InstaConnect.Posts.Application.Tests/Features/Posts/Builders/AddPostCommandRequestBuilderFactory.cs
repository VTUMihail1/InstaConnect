namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class AddPostCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommandRequest> _objectBuilderFactory = new();

    public AddPostCommandRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommandRequestBuilder(objectBuilder, user);

        return addRequest;
    }
}
