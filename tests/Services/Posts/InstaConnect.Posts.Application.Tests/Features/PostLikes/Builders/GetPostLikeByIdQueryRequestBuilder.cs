namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostLikeByIdQueryRequest> _objectBuilder;

    public GetPostLikeByIdQueryRequestBuilder(ObjectBuilder<GetPostLikeByIdQueryRequest> objectBuilder, PostLike postLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithUserId(postLike.UserId);
    }

    public GetPostLikeByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public GetPostLikeByIdQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public GetPostLikeByIdQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
