using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedUserAddedAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserAddedEventRequest>(
				p => p.Matches(command, user),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserUpdatedAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserUpdatedEventRequest>(
				p => p.Matches(command, user),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserDeletedAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserDeletedEventRequest>(
				p => p.Matches(command, user),
				cancellationToken);
		}
	}
}
