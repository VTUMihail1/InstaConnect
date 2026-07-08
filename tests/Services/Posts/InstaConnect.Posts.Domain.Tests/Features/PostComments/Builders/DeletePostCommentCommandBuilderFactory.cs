namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class DeletePostCommentCommandBuilderFactory
{
	public DeletePostCommentCommandBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
