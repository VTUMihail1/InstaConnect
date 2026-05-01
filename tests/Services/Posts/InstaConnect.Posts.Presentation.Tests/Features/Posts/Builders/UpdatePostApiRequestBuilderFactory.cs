namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class UpdatePostApiRequestBuilderFactory
{
	public UpdatePostApiRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
