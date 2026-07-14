using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostCommentLikeAddedAsync(
			AddPostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentLikeAddedEventRequest>(
				p => p.Matches(request, postCommentLike),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentLikeDeletedAsync(
			DeletePostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentLikeDeletedEventRequest>(
				p => p.Matches(request, postCommentLike),
				cancellationToken);
		}
	}
}
