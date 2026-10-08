namespace InstaConnect.Chats.Domain.Tests.Features.Users.Builders;

public class UpdateUserCommandBuilderFactory
{
	public UpdateUserCommandBuilder Create(User user)
	{
		return new(user);
	}
}
