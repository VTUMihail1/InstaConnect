using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteApiRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.GetAllQueryRequest;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class GetAllPostsQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostsQueryRequest> _objectBuilderFactory = new();

    public GetAllPostsQueryRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostsQueryRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public GetAllPostsQueryRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostsQueryRequestBuilder(objectBuilder, post, user);

        return requestBuilder;
    }
}
