namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeApiRequestBuilderFactory
{
    public AddPostCommentLikeApiRequestBuilder Create(Post post, PostComment postComment, User user)
    {
        return new(post, postComment, user);
    }
}
