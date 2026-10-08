using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;

public interface IPostLikeEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<PostLikeAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<PostLikeDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken);
}
