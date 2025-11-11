namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class UpdatePostCommentApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;
    private string _content;

    public UpdatePostCommentApiRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id;
        _commentId = postComment.CommentId;
        _userId = postComment.UserId;
        _content = PostCommentDataFaker.GetContent();
    }

    public UpdatePostCommentApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public UpdatePostCommentApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

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
