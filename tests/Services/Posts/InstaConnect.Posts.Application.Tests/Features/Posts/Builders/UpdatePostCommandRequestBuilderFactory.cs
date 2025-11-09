namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class UpdatePostCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdatePostCommandRequest> _objectBuilderFactory = new();

    public UpdatePostCommandRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommandRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
