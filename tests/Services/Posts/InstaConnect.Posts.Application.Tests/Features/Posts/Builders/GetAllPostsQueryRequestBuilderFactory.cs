namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostsQueryRequest> _objectBuilderFactory = new();

    public GetAllPostsQueryRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostsQueryRequestBuilder(objectBuilder, post, user);

        return requestBuilder;
    }
}
