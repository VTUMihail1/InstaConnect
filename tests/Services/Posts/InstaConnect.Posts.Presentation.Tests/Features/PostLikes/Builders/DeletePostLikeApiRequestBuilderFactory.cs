namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class DeletePostLikeApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostLikeApiRequest> _objectBuilderFactory = new();

    public DeletePostLikeApiRequestBuilder Create(PostLike postLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostLikeApiRequestBuilder(objectBuilder, postLike);

        return requestBuilder;
    }
}
