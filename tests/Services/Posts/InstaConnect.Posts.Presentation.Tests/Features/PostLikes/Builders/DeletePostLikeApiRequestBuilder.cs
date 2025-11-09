namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class DeletePostLikeApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostLikeApiRequest> _objectBuilder;

    public DeletePostLikeApiRequestBuilder(ObjectBuilder<DeletePostLikeApiRequest> objectBuilder, PostLike postLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithUserId(postLike.UserId);
    }

    public DeletePostLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostLikeApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
