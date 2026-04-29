namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentBuilderFactory
{
	public PostCommentBuilder Create(Post post, User user)
	{
		return new(post, user);
	}
}
