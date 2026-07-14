using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedUserClaimAddedAsync(
			AddUserClaimCommandRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserClaimAddedEventRequest>(
				p => p.Matches(request, userClaim),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserClaimDeletedAsync(
			DeleteUserClaimCommandRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserClaimDeletedEventRequest>(
				p => p.Matches(request, userClaim),
				cancellationToken);
		}
	}
}
