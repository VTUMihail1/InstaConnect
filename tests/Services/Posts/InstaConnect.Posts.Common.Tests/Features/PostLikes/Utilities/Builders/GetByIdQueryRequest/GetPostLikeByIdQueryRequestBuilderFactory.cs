using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetByIdQueryRequest;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class GetPostLikeByIdQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostLikeByIdQueryRequest> _objectBuilderFactory = new();

    public GetPostLikeByIdQueryRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostLikeByIdQueryRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public GetPostLikeByIdQueryRequestBuilder Create(PostLike postLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostLikeByIdQueryRequestBuilder(objectBuilder, postLike);

        return requestBuilder;
    }
}
