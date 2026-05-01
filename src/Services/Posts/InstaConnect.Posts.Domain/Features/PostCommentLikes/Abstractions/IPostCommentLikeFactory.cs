namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeFactory
{
	public PostCommentLike Create(PostCommentId commentId, UserId userId);
}
