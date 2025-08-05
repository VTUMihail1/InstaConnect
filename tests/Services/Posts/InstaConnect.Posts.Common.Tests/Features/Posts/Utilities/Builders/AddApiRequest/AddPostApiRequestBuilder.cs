using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class AddPostApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostApiRequest> _objectBuilder;

    public AddPostApiRequestBuilder(ObjectBuilder<AddPostApiRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithUserId(UserDataFaker.GetId());
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostApiRequestBuilder(ObjectBuilder<AddPostApiRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithUserId(user.Id);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

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

    public AddPostApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
