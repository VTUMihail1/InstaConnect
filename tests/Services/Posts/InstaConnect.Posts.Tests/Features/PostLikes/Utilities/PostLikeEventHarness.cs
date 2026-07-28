using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<PostLikeAddedEventRequest> PublishedLikeAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostLikeAddedEventRequest>(cancellationToken);
		}

		public async Task<PostLikeDeletedEventRequest> PublishedLikeDeletedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostLikeDeletedEventRequest>(cancellationToken);
		}
	}
}
