using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class DeletePostCommentCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommentCommandRequest> _objectBuilderFactory = new();

    public DeletePostCommentCommandRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentCommandRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
