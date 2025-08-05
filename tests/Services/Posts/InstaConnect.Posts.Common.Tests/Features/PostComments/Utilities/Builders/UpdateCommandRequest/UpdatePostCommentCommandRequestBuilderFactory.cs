using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.UpdateCommandRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class UpdatePostCommentCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdatePostCommentCommandRequest> _objectBuilderFactory = new();

    public UpdatePostCommentCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommentCommandRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public UpdatePostCommentCommandRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommentCommandRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
