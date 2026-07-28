using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<UserAddedEventRequest> ConsumedAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.ConsumedAsync<UserAddedEventRequest>(cancellationToken);
		}

		public async Task<UserUpdatedEventRequest> ConsumedUpdatedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.ConsumedAsync<UserUpdatedEventRequest>(cancellationToken);
		}

		public async Task<UserDeletedEventRequest> ConsumedDeletedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.ConsumedAsync<UserDeletedEventRequest>(cancellationToken);
		}

		public async Task<UserAddedEventRequest> FaultedAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.FaultedAsync<UserAddedEventRequest>(cancellationToken);
		}

		public async Task<UserUpdatedEventRequest> FaultedUpdatedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.FaultedAsync<UserUpdatedEventRequest>(cancellationToken);
		}

		public async Task<UserDeletedEventRequest> FaultedDeletedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.FaultedAsync<UserDeletedEventRequest>(cancellationToken);
		}
	}
}
