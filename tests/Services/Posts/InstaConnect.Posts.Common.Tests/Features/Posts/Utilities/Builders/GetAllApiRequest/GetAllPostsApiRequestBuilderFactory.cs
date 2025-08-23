using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteApiRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.GetAllApiRequest;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class GetAllPostsApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostsApiRequest> _objectBuilderFactory = new();

    public GetAllPostsApiRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostsApiRequestBuilder(objectBuilder, post, user);

        return requestBuilder;
    }
}
