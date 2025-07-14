using System.Runtime.CompilerServices;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class AddPostCommandBuilder
{
    private readonly ObjectBuilder<AddPostCommand> _objectBuilder = new();

    public AddPostCommandBuilder() : this(new PostBuilder().Create())
    {
    }

    public AddPostCommandBuilder(Post post)
    {
        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public AddPostCommandBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId, type);

        return this;
    }

    public AddPostCommandBuilder WithInvalidUserId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId(), type);

        return this;
    }

    public AddPostCommandBuilder WithTitle(string title, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Title, title, type);

        return this;
    }

    public AddPostCommandBuilder WithContent(string content, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Content, content, type);

        return this;
    }

    public AddPostCommand Create()
    {
        return _objectBuilder.Create();
    }
}
