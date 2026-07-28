using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<PostCommentAddedEventRequest> PublishedCommentAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostCommentAddedEventRequest>(cancellationToken);
		}

		public async Task<PostCommentUpdatedEventRequest> PublishedCommentUpdatedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostCommentUpdatedEventRequest>(cancellationToken);
		}

		public async Task<PostCommentDeletedEventRequest> PublishedCommentDeletedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostCommentDeletedEventRequest>(cancellationToken);
		}
	}
}
