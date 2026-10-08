using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Tests.Features.Follows.Abstractions;

public interface IFollowEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<FollowAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<FollowDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken);
}
