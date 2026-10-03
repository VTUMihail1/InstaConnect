namespace InstaConnect.Follows.Domain.Tests.Features.Users.Builders;

public class DeleteUserCommandBuilderFactory
{
	public DeleteUserCommandBuilder Create(User user)
	{
		return new(user);
	}
}
