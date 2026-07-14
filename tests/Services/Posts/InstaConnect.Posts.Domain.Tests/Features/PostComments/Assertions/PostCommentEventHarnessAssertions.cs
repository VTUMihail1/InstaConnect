using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

public static class PostCommentEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostCommentAddedAsync(
			AddPostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentAddedEventRequest>(
				p => p.Matches(command, postComment),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentUpdatedAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentUpdatedEventRequest>(
				p => p.Matches(command, postComment),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostCommentDeletedAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostCommentDeletedEventRequest>(
				p => p.Matches(command, postComment),
				cancellationToken);
		}
	}
}
