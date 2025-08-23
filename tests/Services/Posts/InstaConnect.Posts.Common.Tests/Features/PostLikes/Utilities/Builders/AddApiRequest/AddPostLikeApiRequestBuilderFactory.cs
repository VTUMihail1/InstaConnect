using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class AddPostLikeApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostLikeApiRequest> _objectBuilderFactory = new();

    public AddPostLikeApiRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostLikeApiRequestBuilder(objectBuilder, post, user);

        return requestBuilder;
    }
}
