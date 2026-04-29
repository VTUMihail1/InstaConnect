namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class UpdatePostCommentCommandRequestBuilderFactory
{
	public UpdatePostCommentCommandRequestBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
