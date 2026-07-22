using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<PostCommentLikeAddedEventRequest> PublishedCommentLikeAddedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostCommentLikeAddedEventRequest>(cancellationToken);
		}

		public async Task<PostCommentLikeDeletedEventRequest> PublishedCommentLikeDeletedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<PostCommentLikeDeletedEventRequest>(cancellationToken);
		}
	}
}
