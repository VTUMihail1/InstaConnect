using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class AddPostApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostApiRequest> _objectBuilder;

    public AddPostApiRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<AddPostApiRequest>();

        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostApiRequestBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<AddPostApiRequest>();

        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public AddPostApiRequestBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public AddPostApiRequestBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public AddPostApiRequestBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Body.Title, title);

        return this;
    }

    public AddPostApiRequestBuilder WithContent(string content)
    {
        _objectBuilder.With(p => p.Body.Content, content);

        return this;
    }

    public AddPostApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
