namespace InstaConnect.Shared.Business.Abstractions;

public interface IEventPublisher
{
    Task PublishAsync(object message, CancellationToken cancellationToken);
}
