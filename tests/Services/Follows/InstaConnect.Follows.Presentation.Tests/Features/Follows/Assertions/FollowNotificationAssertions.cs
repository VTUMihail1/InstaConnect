using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowNotificationAssertions
{
	extension(FollowAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddFollowApiRequest request,
			Follow follow)
		{
			r.ShouldSatisfy(f => f.Matches(request, follow));
		}
	}
}
