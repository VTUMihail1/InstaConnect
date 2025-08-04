using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddCommandRequest;

public class AddPostLikeCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostLikeCommandRequest> _objectBuilderFactory = new();

    public AddPostLikeCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostLikeCommandRequestBuilder(objectBuilder);

        return addRequest;
    }

    public AddPostLikeCommandRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostLikeCommandRequestBuilder(objectBuilder, post, user);

        return addRequest;
    }
}
