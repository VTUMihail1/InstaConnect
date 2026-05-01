using InstaConnect.Common.Events.Features.Common.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Presentation.Features.Events.Abstractions;

public interface IEventHandler<in TEvent> : IConsumer<TEvent>
	where TEvent : class, IEventRequest;
