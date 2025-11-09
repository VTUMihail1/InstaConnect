namespace InstaConnect.Common.Tests.Events;

public interface IEventHarness
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
    Task<bool> ConsumedAsync<T>(Func<T, bool> predicate, CancellationToken cancellationToken) where T : class;
    Task<bool> PublishedAsync<T>(Func<T, bool> predicate, CancellationToken cancellationToken) where T : class;
    Task<bool> FaultedAsync<T>(Func<T, bool> predicate, string errorMessage, CancellationToken cancellationToken) where T : class;
    Task StartAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);
}
