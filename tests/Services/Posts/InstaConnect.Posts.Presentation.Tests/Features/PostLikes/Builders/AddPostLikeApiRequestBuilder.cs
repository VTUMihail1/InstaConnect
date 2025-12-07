namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class AddPostLikeApiRequestBuilder
{
    private string _id;
    private string _userId;

    public AddPostLikeApiRequestBuilder(Post post, User user)
    {
        _id = post.Id.Id;
        _userId = user.Id.Id;
    }

    public AddPostLikeApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public AddPostLikeApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public AddPostLikeApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public AddPostLikeApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public AddPostLikeApiRequest Build()
    {
        return new(_id, _userId);
    }
}
