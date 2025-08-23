using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddCommandRequest;
public class AddPostCommandRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommandRequest> _objectBuilder;

    public AddPostCommandRequestBuilder(ObjectBuilder<AddPostCommandRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithUserId(user.Id);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommandRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Title, title, transformer);

        return this;
    }

    public AddPostCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Content, content, transformer);

        return this;
    }

    public AddPostCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
