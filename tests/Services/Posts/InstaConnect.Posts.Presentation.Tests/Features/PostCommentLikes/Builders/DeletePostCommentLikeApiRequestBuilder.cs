namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public DeletePostCommentLikeApiRequestBuilder(PostCommentLike postCommentLike)
    {
        _id = postCommentLike.Id.CommentId.Id.Id;
        _commentId = postCommentLike.Id.CommentId.CommentId;
        _userId = postCommentLike.Id.UserId.Id;
    }

    public DeletePostCommentLikeApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public DeletePostCommentLikeApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostCommentLikeApiRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public DeletePostCommentLikeApiRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public DeletePostCommentLikeApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public DeletePostCommentLikeApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public DeletePostCommentLikeApiRequest Build()
    {
        return new(
            _id,
            _commentId,
            _userId
        );
    }
}
