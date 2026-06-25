namespace InstaConnect.Posts.Domain.Tests.Features.Users.Builders;

public class UpdateUserCommandBuilderFactory
{
	public UpdateUserCommandBuilder Create(User user)
	{
		return new(user);
	}
}
