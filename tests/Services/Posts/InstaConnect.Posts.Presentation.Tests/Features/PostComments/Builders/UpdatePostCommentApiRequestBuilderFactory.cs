namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class UpdatePostCommentApiRequestBuilderFactory
{
	public UpdatePostCommentApiRequestBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
