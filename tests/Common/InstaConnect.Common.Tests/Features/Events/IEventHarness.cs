using InstaConnect.Common.Events.Features.Common.Abstractions;

namespace InstaConnect.Common.Tests.Features.Events;

public interface IEventHarness
{
	public Task<TRequest> ConsumedAsync<TRequest>(CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task<TRequest> FaultedAsync<TRequest>(CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task PublishAsync<TRequest>(TRequest message, CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task<TRequest> PublishedAsync<TRequest>(CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task<ICollection<TRequest>> PublishedRangeAsync<TRequest>(CancellationToken cancellationToken) where TRequest : class, IEventRequest;

	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);
}
