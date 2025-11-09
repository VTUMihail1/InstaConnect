namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetPostByIdQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostByIdQueryRequest> _objectBuilderFactory = new();

    public GetPostByIdQueryRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostByIdQueryRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
