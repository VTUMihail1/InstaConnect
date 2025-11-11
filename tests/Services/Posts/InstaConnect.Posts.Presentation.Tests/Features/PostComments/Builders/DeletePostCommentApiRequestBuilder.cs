namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class DeletePostCommentApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public DeletePostCommentApiRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id;
        _commentId = postComment.CommentId;
        _userId = postComment.UserId;
    }

    public DeletePostCommentApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public DeletePostCommentApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public DeletePostCommentApiRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
