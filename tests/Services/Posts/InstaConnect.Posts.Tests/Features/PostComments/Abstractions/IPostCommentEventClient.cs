using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Tests.Features.PostComments.Abstractions;

public interface IPostCommentEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<PostCommentAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<PostCommentUpdatedEventRequest> PublishedUpdatedAsync(CancellationToken cancellationToken);

	public Task<PostCommentDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken);
}
