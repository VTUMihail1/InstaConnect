using MassTransit.Testing;

namespace InstaConnect.Common.Tests.Utilities.Events;

public class EventHarness : IEventHarness
{
    private readonly ITestHarness _testHarness;

    public EventHarness(ITestHarness testHarness)
    {
        _testHarness = testHarness;
    }

    public async Task<bool> PublishedAsync<T>(Func<T, bool> predicate, CancellationToken cancellationToken)
        where T : class
    {
        var isMessagePublished = await _testHarness.Published
                .Any<T>(e => predicate(e.Context.Message), cancellationToken);

        return isMessagePublished;
    }

    public async Task<bool> ConsumedAsync<T>(Func<T, bool> predicate, CancellationToken cancellationToken)
        where T : class
    {
        var isMessageConsumed = await _testHarness.Consumed
                .Any<T>(e => predicate(e.Context.Message), cancellationToken);

        return isMessageConsumed;
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

