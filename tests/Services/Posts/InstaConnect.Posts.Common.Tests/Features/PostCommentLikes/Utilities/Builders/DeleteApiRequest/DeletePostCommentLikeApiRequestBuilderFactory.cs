using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class DeletePostCommentLikeApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommentLikeApiRequest> _objectBuilderFactory = new();

    public DeletePostCommentLikeApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentLikeApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public DeletePostCommentLikeApiRequestBuilder Create(PostCommentLike postCommentLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentLikeApiRequestBuilder(objectBuilder, postCommentLike);

        return requestBuilder;
    }
}
