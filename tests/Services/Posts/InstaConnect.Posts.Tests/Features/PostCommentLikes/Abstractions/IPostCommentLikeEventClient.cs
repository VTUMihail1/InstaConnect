using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<PostCommentLikeAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<PostCommentLikeDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken);
}
