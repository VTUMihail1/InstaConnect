using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class AddPostApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostApiRequest> _objectBuilderFactory = new();

    public AddPostApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public AddPostApiRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostApiRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
