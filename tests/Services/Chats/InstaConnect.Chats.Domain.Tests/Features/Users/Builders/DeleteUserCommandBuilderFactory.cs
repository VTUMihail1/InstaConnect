namespace InstaConnect.Chats.Domain.Tests.Features.Users.Builders;

public class DeleteUserCommandBuilderFactory
{
	public DeleteUserCommandBuilder Create(User user)
	{
		return new(user);
	}
}
