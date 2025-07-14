using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class UpdatePostApiRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostApiRequest> _objectBuilder = new();

    public UpdatePostApiRequestBuilder() : this(new PostBuilder().Create())
    {
    }

    public UpdatePostApiRequestBuilder(Post post)
    {
        WithId(post.Id);
        WithUserId(post.UserId);
        WithTitle(post.Title);
        WithContent(post.Content);
    }

    public UpdatePostApiRequestBuilder WithId(string id, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, id, type);

        return this;
    }

    public UpdatePostApiRequestBuilder WithInvalidId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId(), type);

        return this;
    }

    public UpdatePostApiRequestBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId, type);

        return this;
    }

    public UpdatePostApiRequestBuilder WithInvalidUserId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId(), type);

        return this;
    }

    public UpdatePostApiRequestBuilder WithTitle(string title, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Body.Title, title, type);

        return this;
    }

    public UpdatePostApiRequestBuilder WithContent(string content, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Body.Content, content, type);

        return this;
    }

    public UpdatePostApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
