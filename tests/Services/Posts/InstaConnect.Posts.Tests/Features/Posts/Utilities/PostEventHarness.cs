using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<PostAddedEventRequest> PublishedAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostAddedEventRequest>(cancellationToken);
		}

		public async Task<PostUpdatedEventRequest> PublishedUpdatedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostUpdatedEventRequest>(cancellationToken);
		}

		public async Task<PostDeletedEventRequest> PublishedDeletedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostDeletedEventRequest>(cancellationToken);
		}
	}
}
