namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeBuilderFactory
{
    private readonly ObjectBuilderFactory<PostLike> _objectBuilderFactory = new();

    public PostLikeBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new PostLikeBuilder(objectBuilder, post, user);

        return entityBuilder;
    }
}
