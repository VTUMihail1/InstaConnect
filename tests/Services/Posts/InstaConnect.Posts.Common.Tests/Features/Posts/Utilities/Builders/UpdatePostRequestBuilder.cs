using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class UpdatePostRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostRequest> _objectBuilder;

    public UpdatePostRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<UpdatePostRequest>();

        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public UpdatePostRequestBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<UpdatePostRequest>();

        WithId(post.Id);
        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public UpdatePostRequestBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UpdatePostRequestBuilder WithDifferentCaseId(string id)
    {
        _objectBuilder.With(p => p.Id, DataFaker.GetDifferentCaseString(id));

        return this;
    }

    public UpdatePostRequestBuilder WithInvalidId()
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId());

        return this;
    }

    public UpdatePostRequestBuilder WithoutId()
    {
        _objectBuilder.Without(p => p.Id);

        return this;
    }

    public UpdatePostRequestBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public UpdatePostRequestBuilder WithDifferentCaseUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, DataFaker.GetDifferentCaseString(userId));

        return this;
    }

    public UpdatePostRequestBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public UpdatePostRequestBuilder WithoutUserId()
    {
        _objectBuilder.Without(p => p.CurrentUserId);

        return this;
    }

    public UpdatePostRequestBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Body.Title, title);

        return this;
    }

    public UpdatePostRequestBuilder WithoutTitle()
    {
        _objectBuilder.Without(p => p.Body.Title);

        return this;
    }

    public UpdatePostRequestBuilder WithContent(string content)
    {
        _objectBuilder.With(p => p.Body.Content, content);

        return this;
    }

    public UpdatePostRequestBuilder WithoutContent()
    {
        _objectBuilder.Without(p => p.Body.Content);

        return this;
    }

    public UpdatePostRequest Create()
    {
        return _objectBuilder.Create();
    }
}
