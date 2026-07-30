using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenEventClient : IForgotPasswordTokenEventClient
{
	private readonly IEventHarness _eventHarness;

	public ForgotPasswordTokenEventClient(IEventHarness eventHarness)
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

	public async Task<ICollection<ForgotPasswordTokenAddedEventRequest>> PublishedAddedRangeAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedRangeAsync<ForgotPasswordTokenAddedEventRequest>(cancellationToken);
	}

	public async Task<ICollection<ForgotPasswordTokenDeletedEventRequest>> PublishedDeletedRangeAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedRangeAsync<ForgotPasswordTokenDeletedEventRequest>(cancellationToken);
	}
}
