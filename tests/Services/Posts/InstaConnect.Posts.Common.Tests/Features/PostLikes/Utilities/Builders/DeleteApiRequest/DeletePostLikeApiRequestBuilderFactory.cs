using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class DeletePostLikeApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostLikeApiRequest> _objectBuilderFactory = new();

    public DeletePostLikeApiRequestBuilder Create(PostLike postLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostLikeApiRequestBuilder(objectBuilder, postLike);

        return requestBuilder;
    }
}
