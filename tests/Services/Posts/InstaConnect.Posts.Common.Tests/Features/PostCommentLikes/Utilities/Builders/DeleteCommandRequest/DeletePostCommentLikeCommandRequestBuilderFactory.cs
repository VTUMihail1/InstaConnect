using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class DeletePostCommentLikeCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommentLikeCommandRequest> _objectBuilderFactory = new();

    public DeletePostCommentLikeCommandRequestBuilder Create(PostCommentLike postCommentLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentLikeCommandRequestBuilder(objectBuilder, postCommentLike);

        return requestBuilder;
    }
}
