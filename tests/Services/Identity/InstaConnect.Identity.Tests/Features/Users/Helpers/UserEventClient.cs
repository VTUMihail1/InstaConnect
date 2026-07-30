using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Tests.Features.Users.Abstractions;

namespace InstaConnect.Identity.Tests.Features.Users.Helpers;

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

	public async Task<UserAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<UserAddedEventRequest>(cancellationToken);
	}

	public async Task<UserUpdatedEventRequest> PublishedUpdatedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<UserUpdatedEventRequest>(cancellationToken);
	}

	public async Task<UserDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<UserDeletedEventRequest>(cancellationToken);
	}
}
