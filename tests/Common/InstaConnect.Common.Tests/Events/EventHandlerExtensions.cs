using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.Events;

public static class EventHandlerExtensions
{
    public static async Task Consume<TEvent>(this IEventHandler<TEvent> eventHandler, TEvent message, CancellationToken cancellationToken)
        where TEvent : class, IEventRequest
    {
        var consumeContext = MockFactory.CreateConsumerContext(message, cancellationToken);

        await eventHandler.Consume(consumeContext);
    }
}

