using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.Users.Builders;

public class UserIdBuilderFactory
{
	public UserIdBuilder Create(UserId id)
	{
		return new(id);
	}
}
