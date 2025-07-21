using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
public class AddPostApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostApiRequest> _objectBuilder = new();

    public AddPostApiRequestBuilder() : this(new PostBuilder().Create())
    {
    }

    public AddPostApiRequestBuilder(Post post)
    {
        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public AddPostApiRequestBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId, type);

        return this;
    }

    public AddPostApiRequestBuilder WithTitle(string title, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Body.Title, title, type);

        return this;
    }

    public AddPostApiRequestBuilder WithContent(string content, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Body.Content, content, type);

        return this;
    }

    public AddPostApiRequest Create(StringVariantType type = StringVariantType.Default)
    {
        return _objectBuilder.Create();
    }
}
