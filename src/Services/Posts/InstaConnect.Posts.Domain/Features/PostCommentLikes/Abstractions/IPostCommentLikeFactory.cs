namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeFactory
{
    public PostCommentLike Create(string id, string commentId, string userId);
}
