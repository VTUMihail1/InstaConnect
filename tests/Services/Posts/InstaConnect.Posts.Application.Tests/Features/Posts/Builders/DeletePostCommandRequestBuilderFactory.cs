namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class DeletePostCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommandRequest> _objectBuilderFactory = new();

    public DeletePostCommandRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommandRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
