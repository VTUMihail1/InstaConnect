namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeCommandBuilderFactory
{
	public AddPostCommentLikeCommandBuilder Create(PostComment postComment, User user)
	{
		return new(postComment, user);
	}
}
