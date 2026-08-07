using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Assertions;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
	extension(Follow u)
	{
		public void ShouldSatisfy(Follow follow)
		{
			u.ShouldSatisfy(u => u.Matches(follow));
		}
	}
}
