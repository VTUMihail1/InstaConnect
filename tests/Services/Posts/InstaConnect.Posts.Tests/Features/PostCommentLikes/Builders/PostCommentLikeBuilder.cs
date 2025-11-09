using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilder
{
    private readonly ObjectBuilder<PostCommentLike> _objectBuilder;

    public PostCommentLikeBuilder(ObjectBuilder<PostCommentLike> objectBuilder, Post post, PostComment postComment, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithCommentId(postComment.Id);
        WithUser(user);
        WithCreatedAt(PostCommentLikeDataFaker.GetCreatedAt());
        WithUpdatedAt(PostCommentLikeDataFaker.GetUpdatedAt());
    }

    public PostCommentLikeBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public PostCommentLikeBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public PostCommentLikeBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public PostCommentLikeBuilder WithUser(User user)
    {
        _objectBuilder.With(p => p.UserId, user.Id);
        _objectBuilder.With(p => p.User, user);

        return this;
    }

    public PostCommentLikeBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.CreatedAt, createdAt, transformer);

        return this;
    }

    public PostCommentLikeBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.UpdatedAt, updatedAt, transformer);

        return this;
    }

    public PostCommentLike Build()
    {
        return _objectBuilder.Build();
    }
}
