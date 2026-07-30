using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Chats.Tests.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Tests.Features.Chats.Helpers;

public class ChatEventClient : IChatEventClient
{
	private readonly IEventHarness _eventHarness;

	public ChatEventClient(IEventHarness eventHarness)
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

	public async Task<ChatAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken)
	{
		return await _eventHarness.PublishedAsync<ChatAddedEventRequest>(cancellationToken);
	}
}
