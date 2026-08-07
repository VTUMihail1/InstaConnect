using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserId ToId(
)
		{
			return user.Id;
		}
	}
}
