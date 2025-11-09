namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommentLikeApiRequest> _objectBuilder;

    public AddPostCommentLikeApiRequestBuilder(ObjectBuilder<AddPostCommentLikeApiRequest> objectBuilder, Post post, PostComment postComment, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithCommentId(postComment.Id);
        WithUserId(user.Id);
    }

    public AddPostCommentLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public AddPostCommentLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommentLikeApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
