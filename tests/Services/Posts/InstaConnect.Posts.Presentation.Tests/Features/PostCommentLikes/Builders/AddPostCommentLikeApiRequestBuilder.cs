namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public AddPostCommentLikeApiRequestBuilder(Post post, PostComment postComment, User user)
    {
        _id = post.Id;
        _commentId = postComment.Id;
        _userId = user.Id;
    }

    public AddPostCommentLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

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
