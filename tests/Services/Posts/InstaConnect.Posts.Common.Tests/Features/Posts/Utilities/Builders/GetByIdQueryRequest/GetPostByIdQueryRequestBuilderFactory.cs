using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.GetByIdQueryRequest;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class GetPostByIdQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostByIdQueryRequest> _objectBuilderFactory = new();

    public GetPostByIdQueryRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostByIdQueryRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
