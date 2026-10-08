namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class UpdatePostCommandBuilderFactory
{
	public UpdatePostCommandBuilder Create(Post post)
	{
		return new(post);
	}
}
