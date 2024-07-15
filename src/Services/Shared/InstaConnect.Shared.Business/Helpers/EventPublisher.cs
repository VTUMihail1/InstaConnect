using InstaConnect.Shared.Business.Abstractions;
using MassTransit;

namespace InstaConnect.Shared.Business.Helpers;

public class EventPublisher : IEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync(object message, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(message, cancellationToken);
    }
}
