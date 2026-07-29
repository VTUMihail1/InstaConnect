using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<UserAddedEventRequest> PublishedAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<UserAddedEventRequest>(cancellationToken);
		}

		public async Task<UserUpdatedEventRequest> PublishedUpdatedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<UserUpdatedEventRequest>(cancellationToken);
		}

		public async Task<UserDeletedEventRequest> PublishedDeletedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<UserDeletedEventRequest>(cancellationToken);
		}
	}
}
