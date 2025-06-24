using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class AddPostRequestBuilder
{
    private readonly ObjectBuilder<AddPostApiRequest> _objectBuilder;

    public AddPostRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<AddPostApiRequest>();

        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostRequestBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<AddPostApiRequest>();

        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public AddPostRequestBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public AddPostRequestBuilder WithDifferentCaseUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, DataFaker.GetDifferentCaseString(userId));

        return this;
    }

    public AddPostRequestBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public AddPostRequestBuilder WithoutUserId()
    {
        _objectBuilder.Without(p => p.CurrentUserId);

        return this;
    }

    public AddPostRequestBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Body.Title, title);

        return this;
    }

    public AddPostRequestBuilder WithoutTitle()
    {
        _objectBuilder.Without(p => p.Body.Title);

        return this;
    }

    public AddPostRequestBuilder WithContent(string content)
    {
        _objectBuilder.With(p => p.Body.Content, content);

        return this;
    }

    public AddPostRequestBuilder WithoutContent()
    {
        _objectBuilder.Without(p => p.Body.Content);

        return this;
    }

    public AddPostApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
