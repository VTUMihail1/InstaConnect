namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;
public class AddPostLikeCommandRequestBuilder
{
    private readonly ObjectBuilder<AddPostLikeCommandRequest> _objectBuilder;

    public AddPostLikeCommandRequestBuilder(ObjectBuilder<AddPostLikeCommandRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(user.Id);
    }

    public AddPostLikeCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public AddPostLikeCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostLikeCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
