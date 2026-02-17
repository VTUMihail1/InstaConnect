using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
    public static async Task ShouldHaveConsumedAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveConsumedAsync<UserAddedEventRequest>(p => p.Matches(request), cancellationToken);
    }

    public static async Task ShouldHaveConsumedAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveConsumedAsync<UserUpdatedEventRequest>(p => p.Matches(request), cancellationToken);
    }

    public static async Task ShouldHaveConsumedAsync(
        this IEventHarness eventHarness,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveConsumedAsync<UserDeletedEventRequest>(p => p.Matches(request), cancellationToken);
    }

    public static async Task ShouldHaveFaultedAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveFaultedAsync<UserAddedEventRequest>(p => p.Matches(request), cancellationToken);
    }

    public static async Task ShouldHaveFaultedAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveFaultedAsync<UserUpdatedEventRequest>(p => p.Matches(request), cancellationToken);
    }

    public static async Task ShouldHaveFaultedAsync(
        this IEventHarness eventHarness,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveFaultedAsync<UserDeletedEventRequest>(p => p.Matches(request), cancellationToken);
    }
}
