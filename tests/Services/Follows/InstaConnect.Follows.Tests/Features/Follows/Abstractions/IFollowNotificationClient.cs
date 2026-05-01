namespace InstaConnect.Follows.Tests.Features.Follows.Abstractions;

public interface IFollowNotificationClient
{
	public Task ConnectAsync(CancellationToken cancellationToken);
	public Task<FollowAddedNotificationRequest> AddedAsync(CancellationToken cancellationToken);
}
