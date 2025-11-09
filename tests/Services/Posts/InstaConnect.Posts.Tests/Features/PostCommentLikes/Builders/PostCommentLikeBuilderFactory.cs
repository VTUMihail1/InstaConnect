namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilderFactory
{
    private readonly ObjectBuilderFactory<PostCommentLike> _objectBuilderFactory = new();

    public PostCommentLikeBuilder Create(Post post, PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new PostCommentLikeBuilder(objectBuilder, post, postComment, user);

        return entityBuilder;
    }
}
