using InstaConnect.Follows.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Follows.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHaveConsumedAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHaveConsumedAsync<UserAddedEventRequest>(p => p.Matches(request), cancellationToken);
		}

		public async Task ShouldHaveConsumedAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHaveConsumedAsync<UserUpdatedEventRequest>(p => p.Matches(request), cancellationToken);
		}

		public async Task ShouldHaveConsumedAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHaveConsumedAsync<UserDeletedEventRequest>(p => p.Matches(request), cancellationToken);
		}

		public async Task ShouldHaveFaultedAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHaveFaultedAsync<UserAddedEventRequest>(p => p.Matches(request), cancellationToken);
		}

		public async Task ShouldHaveFaultedAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHaveFaultedAsync<UserUpdatedEventRequest>(p => p.Matches(request), cancellationToken);
		}

		public async Task ShouldHaveFaultedAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHaveFaultedAsync<UserDeletedEventRequest>(p => p.Matches(request), cancellationToken);
		}
	}
}
