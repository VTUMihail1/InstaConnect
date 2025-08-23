using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteApiRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class DeletePostCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommandRequest> _objectBuilderFactory = new();

    public DeletePostCommandRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommandRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
