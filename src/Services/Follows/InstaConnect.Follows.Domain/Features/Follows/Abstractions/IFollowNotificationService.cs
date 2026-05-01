namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowNotificationService
{
	public Task AddedAsync(FollowAddedNotificationRequest request, CancellationToken cancellationToken);
}
