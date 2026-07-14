using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostCommentAddedAsync(
			AddPostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentAddedEventRequest>(
				p => p.Matches(request, postComment),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentUpdatedAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentUpdatedEventRequest>(
				p => p.Matches(request, postComment),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentDeletedAsync(
			DeletePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentDeletedEventRequest>(
				p => p.Matches(request, postComment),
				cancellationToken);
		}
	}
}
