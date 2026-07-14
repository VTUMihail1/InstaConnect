using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostCommentLikeAddedAsync(
			AddPostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentLikeAddedEventRequest>(
				p => p.Matches(request, postCommentLike),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentLikeDeletedAsync(
			DeletePostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentLikeDeletedEventRequest>(
				p => p.Matches(request, postCommentLike),
				cancellationToken);
		}
	}
}
