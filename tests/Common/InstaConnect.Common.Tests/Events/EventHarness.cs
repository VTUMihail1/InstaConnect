using System;

using InstaConnect.Common.Tests.Assertions;

using MassTransit;
using MassTransit.Testing;

using MongoDB.Driver.Core.Configuration;

namespace InstaConnect.Common.Tests.Events;

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
        where TRequest : class
    {
        await StopAsync(cancellationToken);
        _testHarness = _testHarnessFactory.Create();
        await StartAsync(cancellationToken);

        await _testHarness.Bus.Publish(message, cancellationToken);
        await _testHarness.InactivityTask;
    }

    public async Task ShouldHavePublishedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken)
        where TRequest : class
    {
        var isPublished = await _testHarness.Published
                .Any<TRequest>(e => predicate(e.Context.Message), cancellationToken);

        isPublished.ShouldBeTrue();
    }

    public async Task ShouldHaveFaultedAsync<TRequest>(
        Func<TRequest, bool> predicate,
        CancellationToken cancellationToken)
        where TRequest : class
    {
        var result = await _testHarness.Published
                                   .Any<Fault<TRequest>>(e => predicate(e.Context.Message.Message),
                                   cancellationToken);

        result.ShouldBeTrue();
    }

    public async Task ShouldHaveConsumedAsync<TRequest>(Func<TRequest, bool> predicate, CancellationToken cancellationToken)
        where TRequest : class
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

