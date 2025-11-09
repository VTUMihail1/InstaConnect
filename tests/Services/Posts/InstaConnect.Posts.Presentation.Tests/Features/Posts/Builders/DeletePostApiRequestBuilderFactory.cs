namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class DeletePostApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostApiRequest> _objectBuilderFactory = new();

    public DeletePostApiRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostApiRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
