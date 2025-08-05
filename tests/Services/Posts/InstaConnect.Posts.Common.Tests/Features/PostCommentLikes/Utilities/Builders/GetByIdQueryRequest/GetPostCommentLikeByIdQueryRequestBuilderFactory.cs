using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetByIdQueryRequest;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class GetPostCommentLikeByIdQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostCommentLikeByIdQueryRequest> _objectBuilderFactory = new();

    public GetPostCommentLikeByIdQueryRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentLikeByIdQueryRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder Create(PostCommentLike postCommentLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentLikeByIdQueryRequestBuilder(objectBuilder, postCommentLike);

        return requestBuilder;
    }
}
