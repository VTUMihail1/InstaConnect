namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryRequestBuilderFactory
{
    public GetAllPostCommentLikesQueryRequestBuilder Create(PostCommentLike postCommentLike, User user)
    {
        return new(postCommentLike, user);
    }
}
