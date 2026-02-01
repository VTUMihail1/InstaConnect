namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryRequestBuilderFactory
{
    public GetAllPostCommentLikesQueryRequestBuilder Create(PostCommentLike postCommentLike)
    {
        return new(postCommentLike);
    }
}
