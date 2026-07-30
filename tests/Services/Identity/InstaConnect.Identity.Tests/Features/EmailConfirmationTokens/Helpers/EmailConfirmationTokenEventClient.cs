using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenEventClient : IEmailConfirmationTokenEventClient
{
	private readonly IEventHarness _eventHarness;

	public EmailConfirmationTokenEventClient(IEventHarness eventHarness)
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

	public async Task<EmailConfirmationTokenAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<EmailConfirmationTokenAddedEventRequest>(cancellationToken);
	}

	public async Task<ICollection<EmailConfirmationTokenAddedEventRequest>> PublishedAddedRangeAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedRangeAsync<EmailConfirmationTokenAddedEventRequest>(cancellationToken);
	}

	public async Task<ICollection<EmailConfirmationTokenDeletedEventRequest>> PublishedDeletedRangeAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedRangeAsync<EmailConfirmationTokenDeletedEventRequest>(cancellationToken);
	}
}
