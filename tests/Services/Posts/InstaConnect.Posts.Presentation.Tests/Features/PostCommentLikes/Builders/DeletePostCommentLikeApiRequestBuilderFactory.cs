namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommentLikeApiRequest> _objectBuilderFactory = new();

    public DeletePostCommentLikeApiRequestBuilder Create(PostCommentLike postCommentLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentLikeApiRequestBuilder(objectBuilder, postCommentLike);

        return requestBuilder;
    }
}
