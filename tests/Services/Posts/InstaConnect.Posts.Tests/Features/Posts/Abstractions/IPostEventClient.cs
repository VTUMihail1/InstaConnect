using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Tests.Features.Posts.Abstractions;

public interface IPostEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<PostAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<PostUpdatedEventRequest> PublishedUpdatedAsync(CancellationToken cancellationToken);

	public Task<PostDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken);
}
