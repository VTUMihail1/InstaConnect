using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetAllQueryRequest;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class GetAllPostLikesQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostLikesQueryRequest> _objectBuilderFactory = new();

    public GetAllPostLikesQueryRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostLikesQueryRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public GetAllPostLikesQueryRequestBuilder Create(PostLike postLike, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostLikesQueryRequestBuilder(objectBuilder, postLike, user);

        return requestBuilder;
    }
}
