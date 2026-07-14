using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedUserAddedAsync(
			AddUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserAddedEventRequest>(
				p => p.Matches(request, user),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserUpdatedAsync(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserUpdatedEventRequest>(
				p => p.Matches(request, user),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserDeletedAsync(
			DeleteUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserDeletedEventRequest>(
				p => p.Matches(request, user),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserDeletedAsync(
			DeleteCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserDeletedEventRequest>(
				p => p.Matches(request, user),
				cancellationToken);
		}
	}
}
