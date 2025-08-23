using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class AddPostApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostApiRequest> _objectBuilderFactory = new();

    public AddPostApiRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostApiRequestBuilder(objectBuilder, user);

        return requestBuilder;
    }
}
