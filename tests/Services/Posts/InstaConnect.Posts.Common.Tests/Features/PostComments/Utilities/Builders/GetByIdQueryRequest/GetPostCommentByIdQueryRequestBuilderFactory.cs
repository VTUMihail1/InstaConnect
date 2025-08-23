using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetByIdQueryRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class GetPostCommentByIdQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostCommentByIdQueryRequest> _objectBuilderFactory = new();

    public GetPostCommentByIdQueryRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentByIdQueryRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
