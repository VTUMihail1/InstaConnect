namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;
public class AddPostCommentLikeCommandRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommentLikeCommandRequest> _objectBuilder;

    public AddPostCommentLikeCommandRequestBuilder(ObjectBuilder<AddPostCommentLikeCommandRequest> objectBuilder, Post post, PostComment postComment, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithCommentId(postComment.Id);
        WithUserId(user.Id);
    }

    public AddPostCommentLikeCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommentLikeCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
