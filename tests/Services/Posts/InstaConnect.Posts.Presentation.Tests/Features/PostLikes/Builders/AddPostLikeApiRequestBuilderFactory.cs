namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class AddPostLikeApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostLikeApiRequest> _objectBuilderFactory = new();

    public AddPostLikeApiRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostLikeApiRequestBuilder(objectBuilder, post, user);

        return requestBuilder;
    }
}
