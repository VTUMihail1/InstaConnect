using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Tests.Features.Abstractions;

namespace InstaConnect.Common.Tests.Features.Helpers;

public class TestEventPublisher : IEventPublisher
{
	private readonly IEventClient _eventClient;

	public TestEventPublisher(IEventClient eventClient)
	{
		_eventClient = eventClient;
	}

	public async Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		await _eventClient.PublishAsync(message, cancellationToken);
	}

	public async Task PublishAsync<TEvent>(ICollection<TEvent> messages, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		foreach (var message in messages)
		{
			await _eventClient.PublishAsync(message, cancellationToken);
		}
	}
}
