using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Tests.Features.Users.Abstractions;

public interface IUserEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<UserAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<UserUpdatedEventRequest> PublishedUpdatedAsync(CancellationToken cancellationToken);

	public Task<UserDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken);
}
