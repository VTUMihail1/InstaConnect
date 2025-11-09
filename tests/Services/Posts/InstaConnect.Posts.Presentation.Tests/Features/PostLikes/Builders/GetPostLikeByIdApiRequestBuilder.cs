namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostLikeByIdApiRequest> _objectBuilder;

    public GetPostLikeByIdApiRequestBuilder(ObjectBuilder<GetPostLikeByIdApiRequest> objectBuilder, PostLike postLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithUserId(postLike.UserId);
    }

    public GetPostLikeByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public GetPostLikeByIdApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public GetPostLikeByIdApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
