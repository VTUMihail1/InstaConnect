using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.UpdateApiRequest;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class UpdatePostApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdatePostApiRequest> _objectBuilderFactory = new();

    public UpdatePostApiRequestBuilder Create(Post post)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostApiRequestBuilder(objectBuilder, post);

        return requestBuilder;
    }
}
