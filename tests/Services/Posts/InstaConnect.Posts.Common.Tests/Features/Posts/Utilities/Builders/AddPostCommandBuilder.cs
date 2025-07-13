using System.Runtime.CompilerServices;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class AddPostCommandBuilder
{
    private readonly ObjectBuilder<AddPostCommand> _objectBuilder;

    public AddPostCommandBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<AddPostCommand>();

        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostCommandBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<AddPostCommand>();

        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public AddPostCommandBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public AddPostCommandBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public AddPostCommandBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Title, title);

        return this;
    }

    public AddPostCommandBuilder WithContent(string content)
    {
        _objectBuilder.With(p => p.Content, content);

        return this;
    }

    public AddPostCommand Create()
    {
        return _objectBuilder.Create();
    }
}
