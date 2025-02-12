namespace InstaConnect.Shared.Application.Abstractions;

public interface IEventPublisher
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
}
