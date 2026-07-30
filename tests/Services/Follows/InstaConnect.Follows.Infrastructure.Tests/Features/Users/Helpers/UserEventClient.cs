using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Helpers;

public class UserEventClient : IUserEventClient
{
	private readonly IEventHarness _eventHarness;

	public UserEventClient(IEventHarness eventHarness)
	{
		_eventHarness = eventHarness;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await _eventHarness.StartAsync(cancellationToken);
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _eventHarness.StopAsync(cancellationToken);
	}

	public async Task<UserAddedEventRequest> ConsumedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.ConsumedAsync<UserAddedEventRequest>(cancellationToken);
	}

	public async Task<UserUpdatedEventRequest> ConsumedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.ConsumedAsync<UserUpdatedEventRequest>(cancellationToken);
	}

	public async Task<UserDeletedEventRequest> ConsumedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.ConsumedAsync<UserDeletedEventRequest>(cancellationToken);
	}

	public async Task<UserAddedEventRequest> FaultedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.FaultedAsync<UserAddedEventRequest>(cancellationToken);
	}

	public async Task<UserUpdatedEventRequest> FaultedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.FaultedAsync<UserUpdatedEventRequest>(cancellationToken);
	}

	public async Task<UserDeletedEventRequest> FaultedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.FaultedAsync<UserDeletedEventRequest>(cancellationToken);
	}
}
