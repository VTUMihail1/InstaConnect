using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Posts.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
    public static async Task ShouldHaveConsumedAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveConsumedAsync<UserAddedEventRequest>(p => p.Id == request.Id &&
                                                                               p.Name == request.Name &&
                                                                               p.Email == request.Email &&
                                                                               p.FirstName == request.FirstName &&
                                                                               p.LastName == request.LastName &&
                                                                               p.ProfileImageUrl == request.ProfileImageUrl &&
                                                                               p.CreatedAtUtc == request.CreatedAtUtc &&
                                                                               p.UpdatedAtUtc == request.UpdatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHaveConsumedAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveConsumedAsync<UserUpdatedEventRequest>(p => p.Id == request.Id &&
                                                                               p.Name == request.Name &&
                                                                               p.Email == request.Email &&
                                                                               p.FirstName == request.FirstName &&
                                                                               p.LastName == request.LastName &&
                                                                               p.ProfileImageUrl == request.ProfileImageUrl &&
                                                                               p.UpdatedAtUtc == request.UpdatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHaveConsumedAsync(
        this IEventHarness eventHarness,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveConsumedAsync<UserDeletedEventRequest>(p => p.Id == request.Id, cancellationToken);
    }

    public static async Task ShouldHaveFaultedAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveFaultedAsync<UserAddedEventRequest>(p => p.Id == request.Id &&
                                                                               p.Name == request.Name &&
                                                                               p.Email == request.Email &&
                                                                               p.FirstName == request.FirstName &&
                                                                               p.LastName == request.LastName &&
                                                                               p.ProfileImageUrl == request.ProfileImageUrl &&
                                                                               p.CreatedAtUtc == request.CreatedAtUtc &&
                                                                               p.UpdatedAtUtc == request.UpdatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHaveFaultedAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveFaultedAsync<UserUpdatedEventRequest>(p => p.Id == request.Id &&
                                                                               p.Name == request.Name &&
                                                                               p.Email == request.Email &&
                                                                               p.FirstName == request.FirstName &&
                                                                               p.LastName == request.LastName &&
                                                                               p.ProfileImageUrl == request.ProfileImageUrl &&
                                                                               p.UpdatedAtUtc == request.UpdatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHaveFaultedAsync(
        this IEventHarness eventHarness,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHaveFaultedAsync<UserDeletedEventRequest>(p => p.Id == request.Id, cancellationToken);
    }
}
