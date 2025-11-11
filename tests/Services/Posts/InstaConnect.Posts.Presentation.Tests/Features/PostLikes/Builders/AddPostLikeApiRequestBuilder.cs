namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class AddPostLikeApiRequestBuilder
{
    private string _id;
    private string _userId;

    public AddPostLikeApiRequestBuilder(Post post, User user)
    {
        _id = post.Id;
        _userId = user.Id;
    }

    public AddPostLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public AddPostLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public AddPostLikeApiRequest Build()
    {
        return new(_id, _userId);
    }
}
