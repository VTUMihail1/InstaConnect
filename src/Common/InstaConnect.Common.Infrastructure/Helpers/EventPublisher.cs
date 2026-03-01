using InstaConnect.Common.Events.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Helpers;

public class EventPublisher : IEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
        where TEvent : class, IEventRequest
    {
        await _publishEndpoint.Publish(message, cancellationToken);
    }

    public async Task PublishAsync<TEvent>(ICollection<TEvent> messages, CancellationToken cancellationToken)
        where TEvent : class, IEventRequest
    {
        foreach (var message in messages)
        {
            await PublishAsync(message, cancellationToken);
        }
    }
}
