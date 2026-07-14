using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedFollowAddedAsync(
			AddFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<FollowAddedEventRequest>(
				p => p.Matches(request, follow),
				cancellationToken);
		}

		public async Task ShouldHavePublishedFollowDeletedAsync(
			DeleteFollowCommandRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<FollowDeletedEventRequest>(
				p => p.Matches(request, follow),
				cancellationToken);
		}
	}
}
