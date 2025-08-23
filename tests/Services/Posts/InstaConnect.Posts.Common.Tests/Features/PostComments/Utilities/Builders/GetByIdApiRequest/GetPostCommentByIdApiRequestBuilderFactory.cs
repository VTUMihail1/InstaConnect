using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetByIdApiRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class GetPostCommentByIdApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostCommentByIdApiRequest> _objectBuilderFactory = new();

    public GetPostCommentByIdApiRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentByIdApiRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
