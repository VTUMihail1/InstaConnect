namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public AddPostCommentLikeApiRequestBuilder(PostComment postComment, User user)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
        _userId = user.Id.Id;
    }

    public AddPostCommentLikeApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public AddPostCommentLikeApiRequest Build()
    {
        return new(
            _id,
            _commentId,
            _userId
        );
    }
}
