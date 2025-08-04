using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetByIdApiRequest;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class GetPostLikeByIdApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostLikeByIdApiRequest> _objectBuilderFactory = new();

    public GetPostLikeByIdApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostLikeByIdApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public GetPostLikeByIdApiRequestBuilder Create(PostLike postLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostLikeByIdApiRequestBuilder(objectBuilder, postLike);

        return requestBuilder;
    }
}
