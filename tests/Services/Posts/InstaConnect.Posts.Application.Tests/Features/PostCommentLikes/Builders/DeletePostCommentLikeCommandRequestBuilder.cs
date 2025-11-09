namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeCommandRequestBuilder
{
    private readonly ObjectBuilder<DeletePostCommentLikeCommandRequest> _objectBuilder;

    public DeletePostCommentLikeCommandRequestBuilder(ObjectBuilder<DeletePostCommentLikeCommandRequest> objectBuilder, PostCommentLike postCommentLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postCommentLike.Id);
        WithCommentId(postCommentLike.CommentId);
        WithUserId(postCommentLike.UserId);
    }

    public DeletePostCommentLikeCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostCommentLikeCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
