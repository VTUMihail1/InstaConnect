namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostBuilderFactory
{
    private readonly ObjectBuilderFactory<Post> _objectBuilderFactory = new();

    public PostBuilder Create(User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new PostBuilder(objectBuilder, user);

        return entityBuilder;
    }
}
