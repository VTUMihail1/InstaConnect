namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetAllPostsApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostsApiRequest> _objectBuilderFactory = new();

    public GetAllPostsApiRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostsApiRequestBuilder(objectBuilder, post, user);

        return requestBuilder;
    }
}
