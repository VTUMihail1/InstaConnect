namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class UpdatePostCommandRequestBuilderFactory
{
	public UpdatePostCommandRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
