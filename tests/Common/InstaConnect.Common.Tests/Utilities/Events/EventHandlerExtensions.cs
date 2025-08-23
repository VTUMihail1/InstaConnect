using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Tests.Utilities.Events;

public static class EventHandlerExtensions
{
    public static async Task Consume<TEvent>(this IEventHandler<TEvent> eventHandler, TEvent message, CancellationToken cancellationToken)
        where TEvent : class, IEventRequest
    {
        var consumeContext = MockFactory.CreateConsumerContext(message);

        await eventHandler.Consume(consumeContext);
    }
}

