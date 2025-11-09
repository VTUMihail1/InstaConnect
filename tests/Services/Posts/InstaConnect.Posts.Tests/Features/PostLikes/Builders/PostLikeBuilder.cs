using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeBuilder
{
    private readonly ObjectBuilder<PostLike> _objectBuilder;

    public PostLikeBuilder(ObjectBuilder<PostLike> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUser(user);
        WithCreatedAt(PostLikeDataFaker.GetCreatedAt());
        WithUpdatedAt(PostLikeDataFaker.GetUpdatedAt());
    }

    public PostLikeBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public PostLikeBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public PostLikeBuilder WithUser(User user)
    {
        _objectBuilder.With(p => p.UserId, user.Id);
        _objectBuilder.With(p => p.User, user);

        return this;
    }

    public PostLikeBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.CreatedAt, createdAt, transformer);

        return this;
    }

    public PostLikeBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.UpdatedAt, updatedAt, transformer);

        return this;
    }

    public PostLike Build()
    {
        return _objectBuilder.Build();
    }
}
