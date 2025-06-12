using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class DeletePostRequestBuilder
{
    private readonly ObjectBuilder<DeletePostRequest> _objectBuilder;

    public DeletePostRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<DeletePostRequest>();

        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public DeletePostRequestBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<DeletePostRequest>();

        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostRequestBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public DeletePostRequestBuilder WithDifferentCaseId(string id)
    {
        _objectBuilder.With(p => p.Id, DataFaker.GetDifferentCaseString(id));

        return this;
    }

    public DeletePostRequestBuilder WithInvalidId()
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId());

        return this;
    }

    public DeletePostRequestBuilder WithoutId()
    {
        _objectBuilder.Without(p => p.Id);

        return this;
    }

    public DeletePostRequestBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public DeletePostRequestBuilder WithDifferentCaseUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, DataFaker.GetDifferentCaseString(userId));

        return this;
    }

    public DeletePostRequestBuilder WithInvalidUserId()
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId());

        return this;
    }

    public DeletePostRequestBuilder WithoutUserId()
    {
        _objectBuilder.Without(p => p.CurrentUserId);

        return this;
    }

    public DeletePostRequest Create()
    {
        return _objectBuilder.Create();
    }
}
