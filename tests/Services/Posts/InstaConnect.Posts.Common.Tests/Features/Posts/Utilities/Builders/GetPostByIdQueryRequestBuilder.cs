using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetPostByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostByIdQueryRequest> _objectBuilder = new();

    public GetPostByIdQueryRequestBuilder() : this(new PostBuilder().Create())
    {
    }

    public GetPostByIdQueryRequestBuilder(Post post)
    {
        WithId(post.Id);
    }

    public GetPostByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostByIdQueryRequest Create()
    {
        return _objectBuilder.Create();
    }
}
