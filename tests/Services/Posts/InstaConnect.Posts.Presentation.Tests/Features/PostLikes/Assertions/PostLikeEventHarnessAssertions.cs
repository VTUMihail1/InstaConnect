using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostLikeAddedAsync(
			AddPostLikeApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostLikeAddedEventRequest>(
				p => p.Matches(request, postLike),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostLikeDeletedAsync(
			DeletePostLikeApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostLikeDeletedEventRequest>(
				p => p.Matches(request, postLike),
				cancellationToken);
		}
	}
}
