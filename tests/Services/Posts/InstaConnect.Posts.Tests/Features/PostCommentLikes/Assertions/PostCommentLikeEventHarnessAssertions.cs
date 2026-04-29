using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostCommentLikeAddedAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentLikeAddedEventRequest>(
				p => p.Matches(postCommentLike),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentLikeDeletedAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentLikeDeletedEventRequest>(
				p => p.Matches(postCommentLike),
				cancellationToken);
		}
	}
}
