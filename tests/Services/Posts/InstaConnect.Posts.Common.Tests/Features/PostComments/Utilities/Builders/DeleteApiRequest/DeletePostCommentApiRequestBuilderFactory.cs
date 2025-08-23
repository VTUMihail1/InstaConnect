using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class DeletePostCommentApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommentApiRequest> _objectBuilderFactory = new();

    public DeletePostCommentApiRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentApiRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
