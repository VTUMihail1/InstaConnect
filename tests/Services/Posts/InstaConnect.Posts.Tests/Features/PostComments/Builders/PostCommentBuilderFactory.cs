namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentBuilderFactory
{
    private readonly ObjectBuilderFactory<PostComment> _objectBuilderFactory = new();

    public PostCommentBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new PostCommentBuilder(objectBuilder, post, user);

        return entityBuilder;
    }
}
