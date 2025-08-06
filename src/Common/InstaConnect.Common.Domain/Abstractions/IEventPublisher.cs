using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Domain.Abstractions;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
        where TEvent : class, IEventRequest;
}
