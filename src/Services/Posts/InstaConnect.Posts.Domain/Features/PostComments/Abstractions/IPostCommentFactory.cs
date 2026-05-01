namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentFactory
{
	public PostComment Create(PostId id, UserId userId, string content);
}
