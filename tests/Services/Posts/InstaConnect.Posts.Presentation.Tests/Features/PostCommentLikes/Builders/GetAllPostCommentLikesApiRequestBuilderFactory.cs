namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesApiRequestBuilderFactory
{
    public GetAllPostCommentLikesApiRequestBuilder Create(PostCommentLike postCommentLike, User user)
    {
        return new(postCommentLike, user);
    }
}
