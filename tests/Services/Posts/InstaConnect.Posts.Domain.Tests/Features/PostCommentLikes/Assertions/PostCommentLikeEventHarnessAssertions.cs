using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostCommentLikeAddedAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentLikeAddedEventRequest>(
				p => p.Matches(command, postCommentLike),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentLikeDeletedAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentLikeDeletedEventRequest>(
				p => p.Matches(command, postCommentLike),
				cancellationToken);
		}
	}
}
