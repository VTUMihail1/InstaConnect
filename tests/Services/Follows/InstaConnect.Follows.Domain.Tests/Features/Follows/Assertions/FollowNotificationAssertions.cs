using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowNotificationAssertions
{
	extension(FollowAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddFollowCommand command,
			Follow follow)
		{
			r.ShouldSatisfy(f => f.Matches(command, follow));
		}
	}
}
