using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;

public interface IUserClaimEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<UserClaimAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<UserClaimDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken);
}
