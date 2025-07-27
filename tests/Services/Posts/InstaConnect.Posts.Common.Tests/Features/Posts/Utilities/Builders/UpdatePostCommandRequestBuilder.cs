using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class UpdatePostCommandRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostCommandRequest> _objectBuilder = new();

    public UpdatePostCommandRequestBuilder()
    {
        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public UpdatePostCommandRequestBuilder(Post post)
    {
        WithId(post.Id);
        WithUserId(post.UserId);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public UpdatePostCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Title, title);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Content, content);

        return this;
    }

    public UpdatePostCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
