using InstaConnect.Common.Tests.DataAttributes.Base;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostBuilder
{
    private string _id;
    private string _title;
    private string _content;
    private string _userId;
    private User? _user;
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    public PostBuilder(User user)
    {
        _id = PostDataFaker.GetId();
        _user = user;
        _userId = user.Id;
        _title = PostDataFaker.GetTitle();
        _content = PostDataFaker.GetContent();
        _createdAt = PostDataFaker.GetCreatedAt();
        _updatedAt = PostDataFaker.GetUpdatedAt();
    }

    public PostBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public PostBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _title = transformer.TryTransform(title);

        return this;
    }

    public PostBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public PostBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        if (userId != _user?.Id)
        {
            _user = null;
        }

        _userId = transformer.TryTransform(userId);

        return this;
    }

    public PostBuilder WithUser(User user)
    {
        _user = user;
        _userId = user.Id;

        return this;
    }

    public PostBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _createdAt = transformer.TryTransform(createdAt);

        return this;
    }

    public PostBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _updatedAt = transformer.TryTransform(updatedAt);

        return this;
    }

    public Post Build()
    {
        if (_user == null)
        {
            return new(_id, _title, _content, _userId, _createdAt, _updatedAt);
        }

        return new(_id, _title, _content, _user, _createdAt, _updatedAt);
    }
}
