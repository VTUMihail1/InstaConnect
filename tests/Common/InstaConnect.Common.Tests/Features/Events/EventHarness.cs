using InstaConnect.Common.Events.Features.Common.Abstractions;

using MassTransit;
using MassTransit.Testing;

namespace InstaConnect.Common.Tests.Features.Events;

public class EventHarness : IEventHarness
{
	private readonly ITestHarnessFactory _testHarnessFactory;

	private ITestHarness _testHarness;

	public EventHarness(
		ITestHarnessFactory testHarnessFactory,
		ITestHarness testHarness)
	{
		_testHarnessFactory = testHarnessFactory;
		_testHarness = testHarness;
	}

	public async Task PublishAsync<TRequest>(TRequest message, CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		await StopAsync(cancellationToken);
		_testHarness = _testHarnessFactory.Create();
		await StartAsync(cancellationToken);

		await _testHarness.Bus.Publish(message, cancellationToken);
		await _testHarness.InactivityTask;
	}

	public async Task<TRequest> PublishedAsync<TRequest>(CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		return await _testHarness.Published
				.SelectAsync<TRequest>(cancellationToken)
				.Select(a => a.Context.Message)
				.FirstAsync(cancellationToken);
	}

	public async Task<ICollection<TRequest>> PublishedRangeAsync<TRequest>(CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		return await _testHarness.Published
				.SelectAsync<TRequest>(cancellationToken)
				.Select(a => a.Context.Message)
				.ToListAsync(cancellationToken);
	}

	public async Task<TRequest> FaultedAsync<TRequest>(CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		return await _testHarness
				.Published
				.SelectAsync<Fault<TRequest>>(cancellationToken)
				.Select(a => a.Context.Message.Message)
				.FirstAsync(cancellationToken);
	}

	public async Task<TRequest> ConsumedAsync<TRequest>(CancellationToken cancellationToken)
		where TRequest : class, IEventRequest
	{
		return await _testHarness.Consumed
				.SelectAsync<TRequest>(cancellationToken)
				.Select(a => a.Context.Message)
				.FirstAsync(cancellationToken);
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await _testHarness.Start();
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _testHarness.Stop(cancellationToken);
	}
}

