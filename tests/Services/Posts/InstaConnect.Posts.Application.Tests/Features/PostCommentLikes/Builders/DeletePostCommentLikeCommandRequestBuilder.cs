namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeCommandRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public DeletePostCommentLikeCommandRequestBuilder(PostCommentLike postCommentLike)
    {
        _id = postCommentLike.Id.CommentId.Id.Id;
        _commentId = postCommentLike.Id.CommentId.CommentId;
        _userId = postCommentLike.Id.UserId.Id;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId.CommentId);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId.Id);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public DeletePostCommentLikeCommandRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
