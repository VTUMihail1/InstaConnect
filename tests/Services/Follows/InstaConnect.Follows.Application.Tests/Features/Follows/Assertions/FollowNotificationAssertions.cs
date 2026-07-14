using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowNotificationAssertions
{
	extension(FollowAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddFollowCommandRequest request,
			Follow follow)
		{
			r.ShouldSatisfy(f => f.Matches(request, follow));
		}
	}
}
