namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class AddPostLikeApiRequestBuilderFactory
{
	public AddPostLikeApiRequestBuilder Create(Post post, User user)
	{
		return new(post, user);
	}
}
