using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class PostLikeBuilder
{
    private readonly ObjectBuilder<PostLike> _objectBuilder;

    public PostLikeBuilder(ObjectBuilder<PostLike> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithLikeId(PostLikeDataFaker.GetId());
        WithUser(user);
        WithCreatedAt(PostLikeDataFaker.GetCreatedAt());
        WithUpdatedAt(PostLikeDataFaker.GetUpdatedAt());
    }

    public PostLikeBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public PostLikeBuilder WithLikeId(string likeId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.LikeId, likeId, transformer);

        return this;
    }

    public PostLikeBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

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
        _objectBuilder.With(p => p.CreatedAt, createdAt, transformer);

        return this;
    }

    public PostLikeBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UpdatedAt, updatedAt, transformer);

        return this;
    }

    public PostLike Create()
    {
        return _objectBuilder.Create();
    }
}
