using InstaConnect.Common.Events.Features.Events.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Abstractions;

public interface IEventHandler<in TEvent> : IConsumer<TEvent>
	where TEvent : class, IEventRequest;
