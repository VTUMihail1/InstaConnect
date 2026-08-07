namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class AddFollowCommandBuilderFactory
{
	public AddFollowCommandBuilder Create(User follower, User following)
	{
		return new(follower, following);
	}
}
