namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class UpdatePostApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdatePostApiRequest> _objectBuilderFactory = new();

    public UpdatePostApiRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostApiRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
