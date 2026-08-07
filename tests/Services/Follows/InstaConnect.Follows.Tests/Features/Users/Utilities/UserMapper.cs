using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

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
