namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IEventHandler<in TEvent> : IConsumer<TEvent>
    where TEvent : class, IEventRequest;
