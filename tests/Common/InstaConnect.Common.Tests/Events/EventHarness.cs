using MassTransit;
using MassTransit.Testing;

namespace InstaConnect.Common.Tests.Events;

public class EventHarness : IEventHarness
{
    private readonly ITestHarness _testHarness;

    public EventHarness(ITestHarness testHarness)
    {
        _testHarness = testHarness;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken)
        where T : class
    {
        await _testHarness.Bus.Publish(message, cancellationToken);
        await _testHarness.InactivityTask;
    }

    public async Task<bool> PublishedAsync<T>(Func<T, bool> predicate, CancellationToken cancellationToken)
        where T : class
    {
        var isPublished = await _testHarness.Published
                .Any<T>(e => predicate(e.Context.Message), cancellationToken);

        return isPublished;
    }

    public async Task<bool> FaultedAsync<T>(Func<T, bool> predicate, string errorMessage, CancellationToken cancellationToken)
    where T : class
    {
        var isFaulted = await _testHarness.Published
            .Any<Fault<T>>(e => predicate(e.Context.Message.Message) &&
                                e.Context.Message.Exceptions.FirstOrDefault()?.Message == errorMessage, cancellationToken);

        return isFaulted;
    }

    public async Task<bool> ConsumedAsync<T>(Func<T, bool> predicate, CancellationToken cancellationToken)
        where T : class
    {
        var isConsumed = await _testHarness.Consumed
                .Any<T>(e => predicate(e.Context.Message), cancellationToken);

        return isConsumed;
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

