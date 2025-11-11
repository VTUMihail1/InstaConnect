namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeCommandRequestBuilderFactory
{
    public AddPostCommentLikeCommandRequestBuilder Create(Post post, PostComment postComment, User user)
    {
        return new(post, postComment, user);
    }
}
