using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostLikeAddedAsync(
			AddPostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostLikeAddedEventRequest>(
				p => p.Matches(request, postLike),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostLikeDeletedAsync(
			DeletePostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostLikeDeletedEventRequest>(
				p => p.Matches(request, postLike),
				cancellationToken);
		}
	}
}
