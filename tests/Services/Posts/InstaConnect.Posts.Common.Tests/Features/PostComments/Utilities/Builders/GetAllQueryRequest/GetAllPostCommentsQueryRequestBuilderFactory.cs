using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetAllQueryRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class GetAllPostCommentsQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostCommentsQueryRequest> _objectBuilderFactory = new();

    public GetAllPostCommentsQueryRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostCommentsQueryRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public GetAllPostCommentsQueryRequestBuilder Create(PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostCommentsQueryRequestBuilder(objectBuilder, postComment, user);

        return requestBuilder;
    }
}
