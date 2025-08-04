using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.GetByIdApiRequest;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class GetPostByIdApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostByIdApiRequest> _objectBuilderFactory = new();

    public GetPostByIdApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostByIdApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public GetPostByIdApiRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostByIdApiRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
