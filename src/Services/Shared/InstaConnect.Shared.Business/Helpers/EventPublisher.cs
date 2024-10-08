﻿using InstaConnect.Shared.Business.Abstractions;
using MassTransit;

namespace InstaConnect.Shared.Business.Helpers;

public class EventPublisher : IEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken)
        where T : class
    {
        await _publishEndpoint.Publish(message, cancellationToken);
    }
}
