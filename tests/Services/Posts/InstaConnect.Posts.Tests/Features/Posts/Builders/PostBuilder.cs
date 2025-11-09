using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostBuilder
{
    private readonly ObjectBuilder<Post> _objectBuilder;

    public PostBuilder(ObjectBuilder<Post> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(PostDataFaker.GetId());
        WithUser(user);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
        WithCreatedAt(PostDataFaker.GetCreatedAt());
        WithUpdatedAt(PostDataFaker.GetUpdatedAt());
    }

    public PostBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public PostBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Title, title, transformer);

        return this;
    }

    public PostBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Content, content, transformer);

        return this;
    }

    public PostBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public PostBuilder WithUser(User user)
    {
        _objectBuilder.With(p => p.UserId, user.Id);
        _objectBuilder.With(p => p.User, user);

        return this;
    }

    public PostBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.CreatedAt, createdAt, transformer);

        return this;
    }

    public PostBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.UpdatedAt, updatedAt, transformer);

        return this;
    }

    public Post Build()
    {
        return _objectBuilder.Build();
    }
}
