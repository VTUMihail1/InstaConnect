namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class DeletePostCommentApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostCommentApiRequest> _objectBuilder;

    public DeletePostCommentApiRequestBuilder(ObjectBuilder<DeletePostCommentApiRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
        WithUserId(postComment.UserId);
    }

    public DeletePostCommentApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostCommentApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
