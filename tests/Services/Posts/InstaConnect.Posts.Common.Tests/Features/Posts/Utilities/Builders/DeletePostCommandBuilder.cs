using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class DeletePostCommandBuilder
{
    private readonly ObjectBuilder<DeletePostCommand> _objectBuilder;

    public DeletePostCommandBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<DeletePostCommand>();

        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public DeletePostCommandBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<DeletePostCommand>();

        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostCommandBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public DeletePostCommandBuilder WithDifferentCaseId(string id)
    {
        _objectBuilder.With(p => p.Id, DataFaker.GetDifferentCaseString(id));

        return this;
    }

    public DeletePostCommandBuilder WithInvalidId()
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId());

        return this;
    }

    public DeletePostCommandBuilder WithoutId()
    {
        _objectBuilder.Without(p => p.Id);

        return this;
    }

    public DeletePostCommandBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public DeletePostCommandBuilder WithDifferentCaseUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, DataFaker.GetDifferentCaseString(userId));

        return this;
    }

    public DeletePostCommandBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public DeletePostCommandBuilder WithoutUserId()
    {
        _objectBuilder.Without(p => p.CurrentUserId);

        return this;
    }

    public DeletePostCommand Create()
    {
        return _objectBuilder.Create();
    }
}
