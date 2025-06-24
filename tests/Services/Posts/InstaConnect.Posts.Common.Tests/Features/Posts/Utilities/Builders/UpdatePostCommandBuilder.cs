using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class UpdatePostCommandBuilder
{
    private readonly ObjectBuilder<UpdatePostCommand> _objectBuilder;

    public UpdatePostCommandBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<UpdatePostCommand>();

        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public UpdatePostCommandBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<UpdatePostCommand>();

        WithId(post.Id);
        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public UpdatePostCommandBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UpdatePostCommandBuilder WithDifferentCaseId(string id)
    {
        _objectBuilder.With(p => p.Id, DataFaker.GetDifferentCaseString(id));

        return this;
    }

    public UpdatePostCommandBuilder WithInvalidId()
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId());

        return this;
    }

    public UpdatePostCommandBuilder WithoutId()
    {
        _objectBuilder.Without(p => p.Id);

        return this;
    }

    public UpdatePostCommandBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public UpdatePostCommandBuilder WithDifferentCaseUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, DataFaker.GetDifferentCaseString(userId));

        return this;
    }

    public UpdatePostCommandBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public UpdatePostCommandBuilder WithoutUserId()
    {
        _objectBuilder.Without(p => p.CurrentUserId);

        return this;
    }

    public UpdatePostCommandBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Title, title);

        return this;
    }

    public UpdatePostCommandBuilder WithoutTitle()
    {
        _objectBuilder.Without(p => p.Title);

        return this;
    }

    public UpdatePostCommandBuilder WithContent(string content)
    {
        _objectBuilder.With(p => p.Content, content);

        return this;
    }

    public UpdatePostCommandBuilder WithoutContent()
    {
        _objectBuilder.Without(p => p.Content);

        return this;
    }

    public UpdatePostCommand Create()
    {
        return _objectBuilder.Create();
    }
}
