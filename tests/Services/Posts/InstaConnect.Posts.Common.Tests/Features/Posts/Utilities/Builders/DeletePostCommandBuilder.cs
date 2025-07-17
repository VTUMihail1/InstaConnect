using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class DeletePostCommandBuilder
{
    private readonly ObjectBuilder<DeletePostCommand> _objectBuilder = new();

    public DeletePostCommandBuilder() : this(new PostBuilder().Create())
    {
    }

    public DeletePostCommandBuilder(Post post)
    {
        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostCommandBuilder WithId(string id, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, id, type);

        return this;
    }

    public DeletePostCommandBuilder WithInvalidId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId(), type);

        return this;
    }

    public DeletePostCommandBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId, type);

        return this;
    }

    public DeletePostCommandBuilder WithInvalidUserId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId(), type);

        return this;
    }

    public DeletePostCommand Create()
    {
        return _objectBuilder.Create();
    }
}
