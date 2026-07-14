using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedFollowAddedAsync(
			AddFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<FollowAddedEventRequest>(
				p => p.Matches(request, follow),
				cancellationToken);
		}

		public async Task ShouldHavePublishedFollowDeletedAsync(
			DeleteFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<FollowDeletedEventRequest>(
				p => p.Matches(request, follow),
				cancellationToken);
		}
	}
}
