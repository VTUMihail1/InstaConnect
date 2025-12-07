namespace InstaConnect.Common.Tests.Events;

public interface IEventHarness
{
    Task ShouldHaveConsumedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken) where TRequest : class;

    Task ShouldHaveFaultedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken) where TRequest : class;

    Task PublishAsync<TRequest>(TRequest message, CancellationToken cancellationToken) where TRequest : class;

    Task ShouldHavePublishedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken) where TRequest : class;

    Task StartAsync(CancellationToken cancellationToken);

    Task StopAsync(CancellationToken cancellationToken);
}
