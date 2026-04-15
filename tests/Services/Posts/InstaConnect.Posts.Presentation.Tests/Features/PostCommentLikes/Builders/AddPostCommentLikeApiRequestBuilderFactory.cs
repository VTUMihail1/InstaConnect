namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeApiRequestBuilderFactory
{
    public AddPostCommentLikeApiRequestBuilder Create(PostComment postComment, User user)
    {
        return new(postComment, user);
    }
}
