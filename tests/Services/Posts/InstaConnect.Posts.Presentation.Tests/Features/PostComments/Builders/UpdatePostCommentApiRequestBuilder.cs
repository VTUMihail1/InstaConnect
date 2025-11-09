namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class UpdatePostCommentApiRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostCommentApiRequest> _objectBuilder;

    public UpdatePostCommentApiRequestBuilder(ObjectBuilder<UpdatePostCommentApiRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
        WithUserId(postComment.UserId);
        WithContent(PostCommentDataFaker.GetContent());
    }

    public UpdatePostCommentApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Body.Content, content, transformer);

        return this;
    }

    public UpdatePostCommentApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
