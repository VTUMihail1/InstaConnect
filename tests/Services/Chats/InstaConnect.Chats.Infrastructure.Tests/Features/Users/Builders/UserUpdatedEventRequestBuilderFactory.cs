namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Builders;

public class UserUpdatedEventRequestBuilderFactory
{
	public UserUpdatedEventRequestBuilder Create(User user)
	{
		return new(user);
	}
}
