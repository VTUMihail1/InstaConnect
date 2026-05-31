using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Common.Tests.Features.Events;

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

