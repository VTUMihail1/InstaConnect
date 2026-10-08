namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Abstractions;

public interface IUserEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<UserAddedEventRequest> ConsumedAddedAsync(CancellationToken cancellationToken);

	public Task<UserDeletedEventRequest> ConsumedDeletedAsync(CancellationToken cancellationToken);

	public Task<UserUpdatedEventRequest> ConsumedUpdatedAsync(CancellationToken cancellationToken);

	public Task<UserAddedEventRequest> FaultedAddedAsync(CancellationToken cancellationToken);

	public Task<UserDeletedEventRequest> FaultedDeletedAsync(CancellationToken cancellationToken);

	public Task<UserUpdatedEventRequest> FaultedUpdatedAsync(CancellationToken cancellationToken);
}
