using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddCommandRequest;

public class AddPostCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommandRequest> _objectBuilderFactory = new();

    public AddPostCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommandRequestBuilder(objectBuilder);

        return addRequest;
    }

    public AddPostCommandRequestBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommandRequestBuilder(objectBuilder, user);

        return addRequest;
    }
}
