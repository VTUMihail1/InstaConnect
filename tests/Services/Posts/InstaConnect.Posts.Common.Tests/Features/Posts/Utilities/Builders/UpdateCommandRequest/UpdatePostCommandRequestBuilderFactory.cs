using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteApiRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.UpdateCommandRequest;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class UpdatePostCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdatePostCommandRequest> _objectBuilderFactory = new();

    public UpdatePostCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommandRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public UpdatePostCommandRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommandRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
