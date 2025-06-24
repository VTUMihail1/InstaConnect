using System.Runtime.CompilerServices;

using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class PostBuilder
{
    private readonly ObjectBuilder<Post> _objectBuilder;

    public PostBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<Post>();

        WithId(PostDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
        WithUser(UserBuilderFactory.Build().Create());
        WithCreatedAt(PostDataFaker.GetCreatedAt());
        WithUpdatedAt(PostDataFaker.GetUpdatedAt());
    }

    public PostBuilder(User user)
    {
        _objectBuilder = ObjectBuilderFactory.Build<Post>();

        WithId(PostDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
        WithUser(user);
        WithCreatedAt(PostDataFaker.GetCreatedAt());
        WithUpdatedAt(PostDataFaker.GetUpdatedAt());
    }

    public PostBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<Post>();

        WithId(post.Id);
        WithTitle(post.Title);
        WithContent(post.Content);
        WithUser(post.User!);
        WithCreatedAt(post.CreatedAt);
        WithUpdatedAt(post.UpdatedAt);
    }

    public PostBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public PostBuilder WithoutId()
    {
        _objectBuilder.Without(p => p.Id);

        return this;
    }

    public PostBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Title, title);

        return this;
    }

    public PostBuilder WithoutTitle()
    {
        _objectBuilder.Without(p => p.Title);

        return this;
    }

    public PostBuilder WithContent(string content)
    {
        _objectBuilder.With(p => p.Content, content);

        return this;
    }

    public PostBuilder WithoutContent()
    {
        _objectBuilder.Without(p => p.Content);

        return this;
    }

    public PostBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.UserId, userId);
        _objectBuilder.Without(p => p.User);

        return this;
    }

    public PostBuilder WithUser(User user)
    {
        _objectBuilder.With(p => p.UserId, user.Id);
        _objectBuilder.With(p => p.User, user);

        return this;
    }

    public PostBuilder WithoutUser()
    {
        _objectBuilder.Without(p => p.UserId);
        _objectBuilder.Without(p => p.User);

        return this;
    }

    public PostBuilder WithCreatedAt(DateTimeOffset createdAt)
    {
        _objectBuilder.With(p => p.CreatedAt, createdAt);

        return this;
    }

    public PostBuilder WithoutCreatedAt()
    {
        _objectBuilder.Without(p => p.CreatedAt);

        return this;
    }

    public PostBuilder WithUpdatedAt(DateTimeOffset updatedAt)
    {
        _objectBuilder.With(p => p.UpdatedAt, updatedAt);

        return this;
    }

    public PostBuilder WithoutUpdatedAt()
    {
        _objectBuilder.Without(p => p.UpdatedAt);

        return this;
    }

    public Post Create()
    {
        return _objectBuilder.Create();
    }
}
