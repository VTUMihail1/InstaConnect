using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class DeletePostLikeCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostLikeCommandRequest> _objectBuilderFactory = new();

    public DeletePostLikeCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostLikeCommandRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public DeletePostLikeCommandRequestBuilder Create(PostLike postLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostLikeCommandRequestBuilder(objectBuilder, postLike);

        return requestBuilder;
    }
}
