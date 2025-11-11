namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilderFactory
{
    public PostCommentLikeBuilder Create(Post post, PostComment postComment, User user)
    {
        return new(post, postComment, user);
    }
}
