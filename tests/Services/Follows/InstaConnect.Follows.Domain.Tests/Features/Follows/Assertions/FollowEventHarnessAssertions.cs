using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedFollowAddedAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<FollowAddedEventRequest>(
				p => p.Matches(command, follow),
				cancellationToken);
		}

		public async Task ShouldHavePublishedFollowDeletedAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<FollowDeletedEventRequest>(
				p => p.Matches(command, follow),
				cancellationToken);
		}
	}
}
