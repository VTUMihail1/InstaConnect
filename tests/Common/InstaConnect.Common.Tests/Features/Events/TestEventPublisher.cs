using InstaConnect.Common.Events.Features.Common.Abstractions;

namespace InstaConnect.Common.Tests.Features.Events;

public class TestEventPublisher : IEventPublisher
{
	private readonly IEventHarness _eventHarness;

	public TestEventPublisher(IEventHarness eventHarness)
	{
		_eventHarness = eventHarness;
	}

	public async Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		await _eventHarness.PublishAsync(message, cancellationToken);
	}

	public async Task PublishAsync<TEvent>(ICollection<TEvent> messages, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		foreach (var message in messages)
		{
			await _eventHarness.PublishAsync(message, cancellationToken);
		}
	}
}
