namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class UpdatePostCommentCommandRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostCommentCommandRequest> _objectBuilder;

    public UpdatePostCommentCommandRequestBuilder(ObjectBuilder<UpdatePostCommentCommandRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
        WithUserId(postComment.UserId);
        WithContent(PostCommentDataFaker.GetContent());
    }

    public UpdatePostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Content, content);

        return this;
    }

    public UpdatePostCommentCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
