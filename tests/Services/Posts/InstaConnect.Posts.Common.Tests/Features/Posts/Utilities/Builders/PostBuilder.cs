using System.Runtime.CompilerServices;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class PostBuilder
{
    private readonly ObjectBuilder<Post> _objectBuilder = new();

    public PostBuilder(): this(new UserBuilder().Create())
    {
    }

    public PostBuilder(User user)
    {
        WithId(PostDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
        WithUser(user);
        WithCreatedAt(PostDataFaker.GetCreatedAt());
        WithUpdatedAt(PostDataFaker.GetUpdatedAt());
    }

    public PostBuilder WithId(string id, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, id, type);

        return this;
    }

    public PostBuilder WithTitle(string title, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Title, title, type);

        return this;
    }

    public PostBuilder WithContent(string content, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Content, content, type);

        return this;
    }

    public PostBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.UserId, userId, type);
        _objectBuilder.Without(p => p.User);

        return this;
    }

    public PostBuilder WithUser(User user)
    {
        _objectBuilder.With(p => p.UserId, user.Id);
        _objectBuilder.With(p => p.User, user);

        return this;
    }

    public PostBuilder WithCreatedAt(DateTimeOffset createdAt)
    {
        _objectBuilder.With(p => p.CreatedAt, createdAt);

        return this;
    }

    public PostBuilder WithUpdatedAt(DateTimeOffset updatedAt)
    {
        _objectBuilder.With(p => p.UpdatedAt, updatedAt);

        return this;
    }

    public Post Create()
    {
        return _objectBuilder.Create();
    }
}
