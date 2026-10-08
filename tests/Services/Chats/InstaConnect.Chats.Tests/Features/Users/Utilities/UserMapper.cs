using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserId ToId()
		{
			return user.Id;
		}
	}
}
