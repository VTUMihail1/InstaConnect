using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedUserClaimAddedAsync(
			AddUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserClaimAddedEventRequest>(
				p => p.Matches(request, userClaim),
				cancellationToken);
		}

		public async Task ShouldHavePublishedUserClaimDeletedAsync(
			DeleteUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<UserClaimDeletedEventRequest>(
				p => p.Matches(request, userClaim),
				cancellationToken);
		}
	}
}
