using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<PostLikeAddedEventRequest> PublishedLikeAddedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostLikeAddedEventRequest>(cancellationToken);
		}

		public async Task<PostLikeDeletedEventRequest> PublishedLikeDeletedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostLikeDeletedEventRequest>(cancellationToken);
		}
	}
}
