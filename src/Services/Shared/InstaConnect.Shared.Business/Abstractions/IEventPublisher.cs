namespace InstaConnect.Shared.Business.Abstractions;

public interface IEventPublisher
{
    Task Publish(object message, CancellationToken cancellationToken);
}