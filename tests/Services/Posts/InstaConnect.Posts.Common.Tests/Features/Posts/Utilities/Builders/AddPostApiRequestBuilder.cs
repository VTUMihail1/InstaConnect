using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class AddPostApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostApiRequest> _objectBuilder = new();

    public AddPostApiRequestBuilder()
    {
        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostApiRequestBuilder(User user)
    {
        WithUserId(user.Id);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId, transformer);

        return this;
    }

    public AddPostApiRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Body.Title, title, transformer);

        return this;
    }

    public AddPostApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Body.Content, content, transformer);

        return this;
    }

    public AddPostApiRequest Create(IStringTransformer? transformer = null)
    {
        return _objectBuilder.Create();
    }
}
