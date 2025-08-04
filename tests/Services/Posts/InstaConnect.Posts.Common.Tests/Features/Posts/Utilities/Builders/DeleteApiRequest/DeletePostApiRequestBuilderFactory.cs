using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.DeleteApiRequest;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class DeletePostApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostApiRequest> _objectBuilderFactory = new();

    public DeletePostApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public DeletePostApiRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostApiRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
