using InstaConnect.Common.Tests.DataAttributes.Base;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeBuilder
{
    private string _id;
    private string _userId;
    private User? _user;
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    public PostLikeBuilder(Post post, User user)
    {
        _id = post.Id;
        _user = user;
        _userId = user.Id;
        _createdAt = PostLikeDataFaker.GetCreatedAt();
        _updatedAt = PostLikeDataFaker.GetUpdatedAt();
    }

    public PostLikeBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public PostLikeBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        if (userId != _user?.Id)
        {
            _user = null;
        }

        _userId = transformer.TryTransform(userId);

        return this;
    }

    public PostLikeBuilder WithUser(User user)
    {
        _user = user;
        _userId = user.Id;

        return this;
    }

    public PostLikeBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _createdAt = transformer.TryTransform(createdAt);

        return this;
    }

    public PostLikeBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _updatedAt = transformer.TryTransform(updatedAt);

        return this;
    }

    public PostLike Build()
    {
        if (_user == null)
        {
            return new(_id, _userId, _createdAt, _updatedAt);
        }

        return new(_id, _user, _createdAt, _updatedAt);
    }
}
