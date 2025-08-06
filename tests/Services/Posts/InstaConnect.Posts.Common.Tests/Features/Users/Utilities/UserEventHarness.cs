using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Events;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities;

public static class UserEventHarness
{
    public static async Task<bool> HasConsumedAddedEventAsync(
        this IEventHarness eventHarness,
        User user,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.ConsumedAsync<UserAddedEventRequest>(u => u.Id == user.Id &&
                                                                                     u.FirstName == user.FirstName &&
                                                                                     u.LastName == user.LastName &&
                                                                                     u.Email == user.Email &&
                                                                                     u.Name == user.Name &&
                                                                                     u.ProfileImage == user.ProfileImage, cancellationToken);

        return result;
    }

    public static async Task<bool> HasConsumedUpdatedEventAsync(
        this IEventHarness eventHarness,
        User user,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.ConsumedAsync<UserUpdatedEventRequest>(u => u.Id == user.Id &&
                                                                              u.FirstName == user.FirstName &&
                                                                              u.LastName == user.LastName &&
                                                                              u.Email == user.Email &&
                                                                              u.Name == user.Name &&
                                                                              u.ProfileImage == user.ProfileImage, cancellationToken);

        return result;
    }

    public static async Task<bool> HasConsumedUserDeletedEventAsync(
        this IEventHarness eventHarness,
        User user,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.ConsumedAsync<UserDeletedEventRequest>(p => p.Id == user.Id, cancellationToken);

        return result;
    }
}
