namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class DeletePostCommentApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public DeletePostCommentApiRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
        _userId = postComment.UserId.Id;
    }

    public DeletePostCommentApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId.CommentId);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId.Id);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public DeletePostCommentApiRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
