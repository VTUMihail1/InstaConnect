using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostAddedAsync(
			AddPostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostAddedEventRequest>(
				p => p.Matches(request, post),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostUpdatedAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostUpdatedEventRequest>(
				p => p.Matches(request, post),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostDeletedAsync(
			DeletePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostDeletedEventRequest>(
				p => p.Matches(request, post),
				cancellationToken);
		}
	}
}
