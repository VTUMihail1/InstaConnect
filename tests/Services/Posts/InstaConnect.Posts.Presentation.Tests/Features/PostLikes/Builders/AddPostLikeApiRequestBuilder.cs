namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class AddPostLikeApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostLikeApiRequest> _objectBuilder;

    public AddPostLikeApiRequestBuilder(ObjectBuilder<AddPostLikeApiRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(user.Id);
    }

    public AddPostLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public AddPostLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostLikeApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
