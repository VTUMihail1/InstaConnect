namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class DeletePostCommentApiRequestBuilderFactory
{
	public DeletePostCommentApiRequestBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
