using InstaConnect.Common.Events.Features.Common.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Abstractions;

public interface IEventHandler<in TEvent> : IConsumer<TEvent>
	where TEvent : class, IEventRequest;
