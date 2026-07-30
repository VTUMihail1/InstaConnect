using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Tests.Features.Follows.Helpers;

public class FollowEventClient : IFollowEventClient
{
	private readonly IEventHarness _eventHarness;

	public FollowEventClient(IEventHarness eventHarness)
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

	public async Task<FollowAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<FollowAddedEventRequest>(cancellationToken);
	}

	public async Task<FollowDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<FollowDeletedEventRequest>(cancellationToken);
	}
}
