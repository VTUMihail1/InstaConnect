using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedPostAddedAsync(
			AddPostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostAddedEventRequest>(
				p => p.Matches(request, post),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostUpdatedAsync(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostUpdatedEventRequest>(
				p => p.Matches(request, post),
				cancellationToken);
		}

		public async Task ShouldHavePublishedPostDeletedAsync(
			DeletePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<PostDeletedEventRequest>(
				p => p.Matches(request, post),
				cancellationToken);
		}
	}
}
