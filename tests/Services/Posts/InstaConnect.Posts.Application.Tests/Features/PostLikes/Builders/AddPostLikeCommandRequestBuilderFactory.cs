namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class AddPostLikeCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostLikeCommandRequest> _objectBuilderFactory = new();

    public AddPostLikeCommandRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostLikeCommandRequestBuilder(objectBuilder, post, user);

        return addRequest;
    }
}
