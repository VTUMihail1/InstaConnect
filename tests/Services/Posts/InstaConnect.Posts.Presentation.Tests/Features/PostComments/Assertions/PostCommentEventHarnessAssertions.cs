using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostCommentAddedAsync(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentAddedEventRequest>(
				p => p.Matches(request, postComment),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentUpdatedAsync(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentUpdatedEventRequest>(
				p => p.Matches(request, postComment),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentDeletedAsync(
			DeletePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentDeletedEventRequest>(
				p => p.Matches(request, postComment),
				cancellationToken);
		}
	}
}
