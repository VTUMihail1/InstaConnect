namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class DeletePostLikeCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostLikeCommandRequest> _objectBuilderFactory = new();

    public DeletePostLikeCommandRequestBuilder Create(PostLike postLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostLikeCommandRequestBuilder(objectBuilder, postLike);

        return requestBuilder;
    }
}
