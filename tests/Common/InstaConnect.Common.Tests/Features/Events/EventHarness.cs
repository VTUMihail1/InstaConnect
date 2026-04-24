using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Tests.Features.Assertions;

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

    public async Task ShouldHavePublishedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken)
        where TRequest : class, IEventRequest
    {
        var isPublished = await _testHarness.Published
                .Any<TRequest>(e => predicate(e.Context.Message), cancellationToken);

        isPublished.ShouldBeTrue();
    }

    public async Task ShouldHaveNotPublishedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken)
        where TRequest : class, IEventRequest
    {
        var isPublished = await _testHarness.Published
                .Any<TRequest>(e => predicate(e.Context.Message), cancellationToken);

        isPublished.ShouldBeFalse();
    }

    public async Task ShouldHaveFaultedAsync<TRequest>(
        Func<TRequest, bool> predicate,
        CancellationToken cancellationToken)
        where TRequest : class, IEventRequest
    {
        var result = await _testHarness.Published
                                   .Any<Fault<TRequest>>(e => predicate(e.Context.Message.Message),
                                   cancellationToken);

        result.ShouldBeTrue();
    }

    public async Task ShouldHaveConsumedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken)
        where TRequest : class, IEventRequest
    {
        var result = await _testHarness.Consumed
                .Any<TRequest>(e => predicate(e.Context.Message), cancellationToken);

        result.ShouldBeTrue();
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

