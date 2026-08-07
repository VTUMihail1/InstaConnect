namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class DeleteFollowCommandBuilderFactory
{
	public DeleteFollowCommandBuilder Create(Follow follow)
	{
		return new(follow);
	}
}
