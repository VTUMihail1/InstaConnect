namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeCommandRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public AddPostCommentLikeCommandRequestBuilder(PostComment postComment, User user)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
        _userId = user.Id.Id;
    }

    public AddPostCommentLikeCommandRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId.CommentId);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId.Id);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public AddPostCommentLikeCommandRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
