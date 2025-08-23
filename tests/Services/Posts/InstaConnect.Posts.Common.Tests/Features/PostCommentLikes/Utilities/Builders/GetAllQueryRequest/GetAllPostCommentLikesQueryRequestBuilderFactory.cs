using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetAllQueryRequest;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class GetAllPostCommentLikesQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostCommentLikesQueryRequest> _objectBuilderFactory = new();

    public GetAllPostCommentLikesQueryRequestBuilder Create(PostCommentLike postCommentLike, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostCommentLikesQueryRequestBuilder(objectBuilder, postCommentLike, user);

        return requestBuilder;
    }
}
