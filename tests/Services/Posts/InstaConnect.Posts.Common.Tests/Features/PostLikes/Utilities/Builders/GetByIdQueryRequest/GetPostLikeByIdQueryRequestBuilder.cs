using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetByIdQueryRequest;

public class GetPostLikeByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostLikeByIdQueryRequest> _objectBuilder;

    public GetPostLikeByIdQueryRequestBuilder(ObjectBuilder<GetPostLikeByIdQueryRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostLikeDataFaker.GetId());
    }

    public GetPostLikeByIdQueryRequestBuilder(ObjectBuilder<GetPostLikeByIdQueryRequest> objectBuilder, PostLike postLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
    }

    public GetPostLikeByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostLikeByIdQueryRequest Create()
    {
        return _objectBuilder.Create();
    }
}
