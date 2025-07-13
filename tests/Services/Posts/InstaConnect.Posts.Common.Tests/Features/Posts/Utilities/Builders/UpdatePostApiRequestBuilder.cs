using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class UpdatePostApiRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostApiRequest> _objectBuilder;

    public UpdatePostApiRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<UpdatePostApiRequest>();

        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public UpdatePostApiRequestBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<UpdatePostApiRequest>();

        WithId(post.Id);
        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public UpdatePostApiRequestBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UpdatePostApiRequestBuilder WithUserId(string userId)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public UpdatePostApiRequestBuilder WithTitle(string title)
    {
        _objectBuilder.With(p => p.Body.Title, title);

        return this;
    }

    public UpdatePostApiRequestBuilder WithContent(string content)
    {
        _objectBuilder.With(p => p.Body.Content, content);

        return this;
    }

    public UpdatePostApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
