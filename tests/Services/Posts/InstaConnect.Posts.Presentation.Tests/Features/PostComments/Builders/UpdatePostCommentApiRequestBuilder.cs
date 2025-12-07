namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class UpdatePostCommentApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;
    private string _content;

    public UpdatePostCommentApiRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
        _userId = postComment.UserId.Id;
        _content = PostCommentDataFaker.GetContent();
    }

    public UpdatePostCommentApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithContent(IStringTransformer transformer)
    {
        _content = transformer.Transform(_content);

        return this;
    }

    public UpdatePostCommentApiRequest Build()
    {
        return new(
            _id,
            _commentId,
            _userId,
            new(_content)
        );
    }
}
