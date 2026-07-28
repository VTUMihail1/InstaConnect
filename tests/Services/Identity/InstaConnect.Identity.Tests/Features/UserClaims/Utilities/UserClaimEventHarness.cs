using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<UserClaimAddedEventRequest> PublishedClaimAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<UserClaimAddedEventRequest>(cancellationToken);
		}

		public async Task<UserClaimDeletedEventRequest> PublishedClaimDeletedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<UserClaimDeletedEventRequest>(cancellationToken);
		}
	}
}
