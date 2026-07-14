using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedUserClaimAddedAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserClaimAddedEventRequest>(
				p => p.Matches(command, userClaim),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserClaimDeletedAsync(
			DeleteUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserClaimDeletedEventRequest>(
				p => p.Matches(command, userClaim),
				cancellationToken);
		}
	}
}
