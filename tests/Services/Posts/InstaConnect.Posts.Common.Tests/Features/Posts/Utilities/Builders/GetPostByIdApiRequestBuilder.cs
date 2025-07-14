using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetPostByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostByIdApiRequest> _objectBuilder = new();

    public GetPostByIdApiRequestBuilder() : this(new PostBuilder().Create())
    {
    }

    public GetPostByIdApiRequestBuilder(Post post)
    {
        WithId(post.Id);
    }

    public GetPostByIdApiRequestBuilder WithId(string id, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, id, type);

        return this;
    }

    public GetPostByIdApiRequestBuilder WithInvalidId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId(), type);

        return this;
    }

    public GetPostByIdApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
