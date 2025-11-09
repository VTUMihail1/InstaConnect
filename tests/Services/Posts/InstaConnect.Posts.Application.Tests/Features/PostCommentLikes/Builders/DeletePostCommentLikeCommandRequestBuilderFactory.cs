namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommentLikeCommandRequest> _objectBuilderFactory = new();

    public DeletePostCommentLikeCommandRequestBuilder Create(PostCommentLike postCommentLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentLikeCommandRequestBuilder(objectBuilder, postCommentLike);

        return requestBuilder;
    }
}
