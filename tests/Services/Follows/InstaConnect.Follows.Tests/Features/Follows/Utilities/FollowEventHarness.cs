using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<FollowAddedEventRequest> PublishedAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<FollowAddedEventRequest>(cancellationToken);
		}

		public async Task<FollowDeletedEventRequest> PublishedDeletedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<FollowDeletedEventRequest>(cancellationToken);
		}
	}
}
