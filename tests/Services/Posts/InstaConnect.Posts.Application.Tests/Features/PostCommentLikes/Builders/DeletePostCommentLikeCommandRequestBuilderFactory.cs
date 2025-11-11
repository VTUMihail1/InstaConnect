namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeCommandRequestBuilderFactory
{
    public DeletePostCommentLikeCommandRequestBuilder Create(PostCommentLike postCommentLike)
    {
        return new(postCommentLike);
    }
}
