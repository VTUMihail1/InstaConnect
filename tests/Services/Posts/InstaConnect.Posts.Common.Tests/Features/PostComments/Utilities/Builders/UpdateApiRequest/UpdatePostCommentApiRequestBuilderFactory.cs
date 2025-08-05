using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.UpdateApiRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class UpdatePostCommentApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdatePostCommentApiRequest> _objectBuilderFactory = new();

    public UpdatePostCommentApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommentApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public UpdatePostCommentApiRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommentApiRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
