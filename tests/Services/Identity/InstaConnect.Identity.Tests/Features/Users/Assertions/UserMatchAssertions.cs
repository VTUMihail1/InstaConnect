using InstaConnect.Identity.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(User u)
	{
		public void ShouldSatisfy(User user)
		{
			u.ShouldSatisfy(u => u.Matches(user));
		}
	}
}
