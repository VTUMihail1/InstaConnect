using InstaConnect.Common.Events.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Presentation.Abstractions;

public interface IEventHandler<in TEvent> : IConsumer<TEvent>
    where TEvent : class, IEventRequest;
