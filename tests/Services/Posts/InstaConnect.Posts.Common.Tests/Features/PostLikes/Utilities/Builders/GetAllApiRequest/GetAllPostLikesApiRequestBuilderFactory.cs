using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetAllApiRequest;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;

public class GetAllPostLikesApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostLikesApiRequest> _objectBuilderFactory = new();

    public GetAllPostLikesApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostLikesApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public GetAllPostLikesApiRequestBuilder Create(PostLike postLike, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostLikesApiRequestBuilder(objectBuilder, postLike, user);

        return requestBuilder;
    }
}
