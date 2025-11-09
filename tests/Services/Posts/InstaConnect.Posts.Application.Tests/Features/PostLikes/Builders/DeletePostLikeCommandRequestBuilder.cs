namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class DeletePostLikeCommandRequestBuilder
{
    private readonly ObjectBuilder<DeletePostLikeCommandRequest> _objectBuilder;

    public DeletePostLikeCommandRequestBuilder(ObjectBuilder<DeletePostLikeCommandRequest> objectBuilder, PostLike postLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postLike.Id);
        WithUserId(postLike.UserId);
    }

    public DeletePostLikeCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostLikeCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostLikeCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
