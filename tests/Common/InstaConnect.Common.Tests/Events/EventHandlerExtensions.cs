using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.Events;

public static class EventHandlerExtensions
{
    extension<TEvent>(IEventHandler<TEvent> eventHandler)
        where TEvent : class, IEventRequest
    {
        public async Task Consume(TEvent message, CancellationToken cancellationToken)
        {
            var consumeContext = MockFactory.CreateConsumerContext(message, cancellationToken);

            await eventHandler.Consume(consumeContext);
        }
    }
}

