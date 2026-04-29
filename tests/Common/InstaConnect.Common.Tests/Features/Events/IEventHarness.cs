using InstaConnect.Common.Events.Features.Common.Abstractions;

namespace InstaConnect.Common.Tests.Features.Events;

public interface IEventHarness
{
	public Task ShouldHaveConsumedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task ShouldHaveFaultedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task PublishAsync<TRequest>(TRequest message, CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task ShouldHavePublishedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task ShouldHaveNotPublishedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);
}
