using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class DeletePostApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostApiRequest> _objectBuilder = new();

    public DeletePostApiRequestBuilder() : this(new PostBuilder().Create())
    {
    }

    public DeletePostApiRequestBuilder(Post post)
    {
        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostApiRequestBuilder WithId(string id, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, id, type);

        return this;
    }

    public DeletePostApiRequestBuilder WithInvalidId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId(), type);

        return this;
    }

    public DeletePostApiRequestBuilder WithUserId(string userId, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, userId, type);

        return this;
    }

    public DeletePostApiRequestBuilder WithInvalidUserId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.CurrentUserId, UserDataFaker.GetInvalidId(), type);

        return this;
    }

    public DeletePostApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
