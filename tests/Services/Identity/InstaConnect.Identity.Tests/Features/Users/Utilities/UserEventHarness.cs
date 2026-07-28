using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<UserAddedEventRequest> PublishedAddedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<UserAddedEventRequest>(cancellationToken);
		}

		public async Task<UserUpdatedEventRequest> PublishedUpdatedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<UserUpdatedEventRequest>(cancellationToken);
		}

		public async Task<UserDeletedEventRequest> PublishedDeletedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<UserDeletedEventRequest>(cancellationToken);
		}
	}
}
