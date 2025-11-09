namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class DeletePostCommentCommandRequestBuilder
{
    private readonly ObjectBuilder<DeletePostCommentCommandRequest> _objectBuilder;

    public DeletePostCommentCommandRequestBuilder(ObjectBuilder<DeletePostCommentCommandRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
        WithUserId(postComment.UserId);
    }

    public DeletePostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostCommentCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
