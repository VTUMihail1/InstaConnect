
namespace InstaConnect.Common.Tests.Utilities.Events;

public interface IEventHarness
{
    Task<bool> ConsumedAsync<T>(Func<T, bool> predicate, CancellationToken cancellationToken) where T : class;
    Task<bool> PublishedAsync<T>(Func<T, bool> predicate, CancellationToken cancellationToken) where T : class;
    Task StartAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);
}
