namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class AddPostLikeCommandBuilderFactory
{
	public AddPostLikeCommandBuilder Create(Post post, User user)
	{
		return new(post, user);
	}
}
