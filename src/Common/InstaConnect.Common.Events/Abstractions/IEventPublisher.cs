namespace InstaConnect.Common.Events.Abstractions;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
        where TEvent : class, IEventRequest;

    Task PublishAsync<TEvent>(ICollection<TEvent> messages, CancellationToken cancellationToken)
        where TEvent : class, IEventRequest;
}
