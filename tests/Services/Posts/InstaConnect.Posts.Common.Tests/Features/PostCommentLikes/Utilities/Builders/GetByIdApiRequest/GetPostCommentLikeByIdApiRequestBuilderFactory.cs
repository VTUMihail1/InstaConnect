using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetByIdApiRequest;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class GetPostCommentLikeByIdApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostCommentLikeByIdApiRequest> _objectBuilderFactory = new();

    public GetPostCommentLikeByIdApiRequestBuilder Create(PostCommentLike postCommentLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentLikeByIdApiRequestBuilder(objectBuilder, postCommentLike);

        return requestBuilder;
    }
}
