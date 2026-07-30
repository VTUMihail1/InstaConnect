using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Helpers;

public class UserClaimEventClient : IUserClaimEventClient
{
	private readonly IEventHarness _eventHarness;

	public UserClaimEventClient(IEventHarness eventHarness)
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

	public async Task<UserClaimAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<UserClaimAddedEventRequest>(cancellationToken);
	}

	public async Task<UserClaimDeletedEventRequest> PublishedDeletedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<UserClaimDeletedEventRequest>(cancellationToken);
	}
}
