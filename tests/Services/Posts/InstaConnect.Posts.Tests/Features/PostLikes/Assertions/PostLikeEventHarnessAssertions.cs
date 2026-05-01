using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostLikeAddedAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostLikeAddedEventRequest>(
				p => p.Matches(postLike),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostLikeDeletedAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostLikeDeletedEventRequest>(
				p => p.Matches(postLike),
				cancellationToken);
		}
	}
}
