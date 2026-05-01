using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Assertions;

public static class FollowNotificationAssertions
{
	extension(FollowAddedNotificationRequest request)
	{
		public void ShouldSatisfy(Follow follow)
		{
			request.ShouldSatisfy(f => f.Matches(follow));
		}
	}
}
