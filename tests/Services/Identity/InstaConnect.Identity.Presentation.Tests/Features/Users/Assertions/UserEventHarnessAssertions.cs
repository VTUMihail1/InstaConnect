using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedUserAddedAsync(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserAddedEventRequest>(
				p => p.Matches(request, user),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserUpdatedAsync(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserUpdatedEventRequest>(
				p => p.Matches(request, user),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserDeletedAsync(
			DeleteUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserDeletedEventRequest>(
				p => p.Matches(request, user),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserDeletedAsync(
			DeleteCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserDeletedEventRequest>(
				p => p.Matches(request, user),
				cancellationToken);
		}
	}
}
