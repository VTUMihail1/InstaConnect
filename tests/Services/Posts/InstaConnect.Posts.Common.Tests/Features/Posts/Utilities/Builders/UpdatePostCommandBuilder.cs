using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class UpdatePostCommandBuilder
{
    private readonly ObjectBuilder<UpdatePostCommand> _objectBuilder = new();

    public UpdatePostCommandBuilder() : this(new PostBuilder().Create())
    {
    }

    public UpdatePostCommandBuilder(Post post)
    {
        WithId(post.Id);
        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public UpdatePostCommandBuilder WithId(string id, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UpdatePostCommandBuilder WithInvalidId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId());

        return this;
    }

    public UpdatePostCommandBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public UpdatePostCommandBuilder WithInvalidUserId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public UpdatePostCommandBuilder WithTitle(string title, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Title, title);

        return this;
    }

    public UpdatePostCommandBuilder WithContent(string content, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Content, content);

        return this;
    }

    public UpdatePostCommand Create()
    {
        return _objectBuilder.Create();
    }
}
