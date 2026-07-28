using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

public static class EventHandlerExtensions
{
	extension<TEvent>(IEventHandler<TEvent> eventHandler)
		where TEvent : class, IEventRequest
	{
		public async Task Consume(TEvent message, CancellationToken cancellationToken)
		{
			var consumeContext = InfrastructureMockFactory.CreateConsumerContext(message, cancellationToken);

			await eventHandler.Consume(consumeContext);
		}
	}
}

