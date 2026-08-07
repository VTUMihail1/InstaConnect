namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class UpdatePostCommentCommandBuilderFactory
{
	public UpdatePostCommentCommandBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
