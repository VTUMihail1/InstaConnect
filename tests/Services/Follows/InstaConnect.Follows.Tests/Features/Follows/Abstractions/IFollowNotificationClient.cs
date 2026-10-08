namespace InstaConnect.Follows.Tests.Features.Follows.Abstractions;

public interface IFollowNotificationClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<FollowAddedNotificationRequest> PublishedAddedAsync(CancellationToken cancellationToken);
}
