using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

public static class PostEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostAddedAsync(
			AddPostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostAddedEventRequest>(
				p => p.Matches(command, post),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostUpdatedAsync(
			UpdatePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostUpdatedEventRequest>(
				p => p.Matches(command, post),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostDeletedAsync(
			DeletePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostDeletedEventRequest>(
				p => p.Matches(command, post),
				cancellationToken);
		}
	}
}
