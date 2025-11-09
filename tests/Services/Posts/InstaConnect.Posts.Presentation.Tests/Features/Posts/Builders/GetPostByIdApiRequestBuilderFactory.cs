namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetPostByIdApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostByIdApiRequest> _objectBuilderFactory = new();

    public GetPostByIdApiRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostByIdApiRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
