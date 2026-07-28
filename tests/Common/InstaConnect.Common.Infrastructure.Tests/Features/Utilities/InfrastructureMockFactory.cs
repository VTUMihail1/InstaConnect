using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

public static class InfrastructureMockFactory
{
	public static ConsumeContext<TEvent> CreateConsumerContext<TEvent>(TEvent message, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		var consumeContext = Mocker.Mock<ConsumeContext<TEvent>>();

		consumeContext.Message.ReturnsResponse(message);
		consumeContext.CancellationToken.ReturnsResponse(cancellationToken);

		return consumeContext;
	}
}
