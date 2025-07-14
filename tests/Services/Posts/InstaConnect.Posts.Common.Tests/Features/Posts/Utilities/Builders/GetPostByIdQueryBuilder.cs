using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetPostByIdQueryBuilder
{
    private readonly ObjectBuilder<GetPostByIdQuery> _objectBuilder = new();

    public GetPostByIdQueryBuilder() : this(new PostBuilder().Create())
    {
    }

    public GetPostByIdQueryBuilder(Post post)
    {
        WithId(post.Id);
    }

    public GetPostByIdQueryBuilder WithId(string id, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, id, type);

        return this;
    }

    public GetPostByIdQueryBuilder WithInvalidId(StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId(), type);

        return this;
    }

    public GetPostByIdQuery Create()
    {
        return _objectBuilder.Create();
    }
}
