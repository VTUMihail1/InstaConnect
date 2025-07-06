namespace InstaConnect.Common.Domain.Abstractions;

public interface IEventPublisher
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
}
