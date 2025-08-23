using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.GetByIdQueryRequest;

public class GetPostByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostByIdQueryRequest> _objectBuilder;

    public GetPostByIdQueryRequestBuilder(ObjectBuilder<GetPostByIdQueryRequest> objectBuilder, Post post)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
    }

    public GetPostByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostByIdQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
