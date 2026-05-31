using InstaConnect.Posts.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(User u)
	{
		public void ShouldSatisfy(User user)
		{
			user.ShouldSatisfy(u => u.Matches(user));
		}
	}
}
