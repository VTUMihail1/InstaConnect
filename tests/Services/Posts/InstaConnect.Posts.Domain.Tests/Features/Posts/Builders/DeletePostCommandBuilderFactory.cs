namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class DeletePostCommandBuilderFactory
{
	public DeletePostCommandBuilder Create(Post post)
	{
		return new(post);
	}
}
