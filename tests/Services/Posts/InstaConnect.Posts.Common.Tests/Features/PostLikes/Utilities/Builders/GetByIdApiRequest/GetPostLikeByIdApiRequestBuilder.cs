using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetByIdApiRequest;

public class GetPostLikeByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostLikeByIdApiRequest> _objectBuilder;

    public GetPostLikeByIdApiRequestBuilder(ObjectBuilder<GetPostLikeByIdApiRequest> objectBuilder, PostLike postLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithLikeId(postLike.LikeId);
    }

    public GetPostLikeByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostLikeByIdApiRequestBuilder WithLikeId(string likeId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.LikeId, likeId, transformer);

        return this;
    }

    public GetPostLikeByIdApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
