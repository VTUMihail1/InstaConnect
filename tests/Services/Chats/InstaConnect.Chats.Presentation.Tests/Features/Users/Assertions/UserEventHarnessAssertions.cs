using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHaveConsumedAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			var consumed = await eventHarness.ConsumedAsync<UserAddedEventRequest>(cancellationToken);

			consumed.Matches(request).ShouldBeTrue();
		}

		public async Task ShouldHaveConsumedAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			var consumed = await eventHarness.ConsumedAsync<UserUpdatedEventRequest>(cancellationToken);

			consumed.Matches(request).ShouldBeTrue();
		}

		public async Task ShouldHaveConsumedAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			var consumed = await eventHarness.ConsumedAsync<UserDeletedEventRequest>(cancellationToken);

			consumed.Matches(request).ShouldBeTrue();
		}

		public async Task ShouldHaveFaultedAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			var faulted = await eventHarness.FaultedAsync<UserAddedEventRequest>(cancellationToken);

			faulted.Matches(request).ShouldBeTrue();
		}

		public async Task ShouldHaveFaultedAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			var faulted = await eventHarness.FaultedAsync<UserUpdatedEventRequest>(cancellationToken);

			faulted.Matches(request).ShouldBeTrue();
		}

		public async Task ShouldHaveFaultedAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			var faulted = await eventHarness.FaultedAsync<UserDeletedEventRequest>(cancellationToken);

			faulted.Matches(request).ShouldBeTrue();
		}
	}
}
