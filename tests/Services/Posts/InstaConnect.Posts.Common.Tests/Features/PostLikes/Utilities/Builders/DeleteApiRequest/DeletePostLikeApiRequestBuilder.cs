using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteApiRequest;

public class DeletePostLikeApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostLikeApiRequest> _objectBuilder;

    public DeletePostLikeApiRequestBuilder(ObjectBuilder<DeletePostLikeApiRequest> objectBuilder, PostLike postLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithLikeId(postLike.LikeId);
        WithUserId(postLike.UserId);
    }

    public DeletePostLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostLikeApiRequestBuilder WithLikeId(string likeId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.LikeId, likeId, transformer);

        return this;
    }

    public DeletePostLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostLikeApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
