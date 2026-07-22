using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<PostCommentAddedEventRequest> PublishedCommentAddedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostCommentAddedEventRequest>(cancellationToken);
		}

		public async Task<PostCommentUpdatedEventRequest> PublishedCommentUpdatedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostCommentUpdatedEventRequest>(cancellationToken);
		}

		public async Task<PostCommentDeletedEventRequest> PublishedCommentDeletedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostCommentDeletedEventRequest>(cancellationToken);
		}
	}
}
