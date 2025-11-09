namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class AddPostApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostApiRequest> _objectBuilderFactory = new();

    public AddPostApiRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostApiRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
